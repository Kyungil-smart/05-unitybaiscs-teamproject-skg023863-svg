using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("매니저 연결")]
    [SerializeField] private FloorSystem _floorSystem;
    [SerializeField] private AnomalyManager _anomalyManager;
    [SerializeField] private SceneFlowManager _sceneFlowManager;
    [SerializeField] private ElevatorController _elevatorController;

    [Header("설정")]
    
    [SerializeField] private float _elevatorTravelTime = 3.0f;
    [SerializeField] private float _displayResultTime = 2.0f;

    private bool _isBusy;
    private bool _isFirstSection;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        _isFirstSection = true;
        _floorSystem.InitializeFloorSystem();

        if(_elevatorController != null) 
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

        AudioManager.Instance.PlayButtonSound();
        AudioManager.Instance.SetElevatorMoveSound(true);

        yield return new WaitForSeconds(_elevatorTravelTime);

        AudioManager.Instance.SetElevatorMoveSound(false);
        AudioManager.Instance.PlayArrivalSound();

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

        if(_elevatorController != null)
            _elevatorController.SetFloorText(_floorSystem.CurrentFloor);

        if (_elevatorController != null)
            _elevatorController.ElevatorSequense();

        if (_floorSystem.IsTargetReached())
        {
            yield return new WaitForSeconds(_displayResultTime);
            if (_sceneFlowManager != null) _sceneFlowManager.LoadEnding();
            yield break;
        }

        _anomalyManager.PrepareAnomalySection(false);
        _isBusy = false;
    }
}