using UnityEngine;

public class FloorSystem : MonoBehaviour
{
    [Header("설정")]
    [SerializeField] private int _startFloor = 10;
    [SerializeField] private int _targetFloor = 1;
    [SerializeField] private ElevatorController _elevatorController;

    [Header("사운드 설정")]
    public AudioClip arriveSound;
    [Range(0f, 1f)] public float arriveVolume = 0.3f;

    private int _currentFloor;
    private AudioSource _myAudio; 

    public int CurrentFloor => _currentFloor;

    private void Awake()
    {
        _myAudio = GetComponent<AudioSource>();
    }

    public void InitializeFloorSystem()
    {
        _currentFloor = _startFloor;
        _elevatorController.SetFloorText(_currentFloor);
    }

    public void GoDownOneFloor()
    {
        _currentFloor--;
        _elevatorController.SetFloorText(_currentFloor);
        PlayArriveSound();
    }

    public void ResetToStartFloor()
    {
        _currentFloor = _startFloor;
        _elevatorController.SetFloorText(_currentFloor);
        PlayArriveSound();
    }

    private void PlayArriveSound()
    {
        _myAudio.PlayOneShot(arriveSound, arriveVolume);
    }

    public bool IsTargetReached()
    {
        return _currentFloor <= _targetFloor;
    }
}