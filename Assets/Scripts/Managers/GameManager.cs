using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("매니저 연결")]
    [SerializeField] private FloorSystem _floorSystem;
    [SerializeField] private AnomalyManager _anomalyManager;
    [SerializeField] private ElevatorController _elevatorController;

    [Header("오디오 설정 (직접 재생)")]
    [SerializeField] private AudioSource _myAudio;
    [SerializeField] private AudioClip buttonFeedbackSound;
    [SerializeField] private AudioClip elevatorMoveSound;
    [Range(0f, 1f)] public float buttonVolume = 1f;
    [Range(0f, 1f)] public float moveVolume = 0.5f;

    [Header("설정")]
    [SerializeField] private float _elevatorTravelTime = 3.0f;
    [SerializeField] private float _displayResultTime = 2.0f;

    private bool _isBusy;
    private bool _isFirstSection;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (_myAudio == null) _myAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _isFirstSection = true;
        _floorSystem.InitializeFloorSystem();

        if (_elevatorController != null)
            _elevatorController.SetFloorText(_floorSystem.CurrentFloor);

        _anomalyManager.PrepareAnomalySection(true);
    }

    public void OnPlayerChoice(PlayerChoice playerChoice)
    {
        if (_isBusy) return;
        StartCoroutine(HandleElevatorSequence(playerChoice));
    }

    private IEnumerator HandleElevatorSequence(PlayerChoice playerChoice)
    {
        _isBusy = true;

        if (buttonFeedbackSound != null && _myAudio != null)
        {
            _myAudio.PlayOneShot(buttonFeedbackSound, buttonVolume);
        }

        if (elevatorMoveSound != null && _myAudio != null)
        {
            _myAudio.clip = elevatorMoveSound;
            _myAudio.loop = true;
            _myAudio.volume = moveVolume;
            _myAudio.Play();
        }

        yield return new WaitForSeconds(_elevatorTravelTime);

        if (_myAudio != null && _myAudio.clip == elevatorMoveSound)
        {
            _myAudio.Stop();
            _myAudio.loop = false;
        }

        if (_isFirstSection)
        {
            _isFirstSection = false;
            _floorSystem.GoDownOneFloor();
        }
        else
        {
            if (_anomalyManager.IsPlayerChoiceCorrect(playerChoice))
                _floorSystem.GoDownOneFloor();
            else
                _floorSystem.ResetToStartFloor();
        }

        if (_elevatorController != null)
            _elevatorController.SetFloorText(_floorSystem.CurrentFloor);

        _anomalyManager.PrepareAnomalySection(false);

        if (_elevatorController != null)
            _elevatorController.ElevatorSequense();

        if (_floorSystem.IsTargetReached())
        {
            yield return new WaitForSeconds(_displayResultTime);
            
            if (SceneFlowManager.Instance != null) 
                SceneFlowManager.Instance.LoadEnding();
            
            yield break;
        }

        _isBusy = false;
    }
}