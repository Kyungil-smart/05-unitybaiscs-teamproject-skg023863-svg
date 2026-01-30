using UnityEngine;

public class FloorSystem : MonoBehaviour
{
    [Header("설정")]
    [SerializeField] private int _startFloor = 10;
    [SerializeField] private int _targetFloor = 1;

    private int _currentFloor;

    public int CurrentFloor => _currentFloor;

    public void InitializeFloorSystem()
    {
        _currentFloor = _startFloor;
    }

    public void GoDownOneFloor()
    {
        _currentFloor--;
    }

    public void ResetToStartFloor()
    {
        _currentFloor = _startFloor;
    }

    public bool IsTargetReached()
    {
        return _currentFloor <= _targetFloor;
    }
}