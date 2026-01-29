using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSystem : MonoBehaviour
{
    [Header("설정")]
    [SerializeField] private int _startFloor = 10; // 시작 층수 (예: 10층)
    [SerializeField] private int _targetFloor = 1;  // 목표 층수 (1층 도달 시 클리어)

    private int _currentFloor; // 현재 플레이어가 머물고 있는 층수

    // 외부에서 현재 층수를 확인할 수 있게 공개 (읽기 전용)
    public int CurrentFloor => _currentFloor;

    // 게임 시작 시 호출: 현재 층을 설정된 시작 층수로 초기화합니다.
    public void InitializeFloorSystem()
    {
        _currentFloor = _startFloor;
    }

    // 정답을 맞혔을 때 호출: 한 층 아래로 내려갑니다. (예: 10층 -> 9층)
    public void GoDownOneFloor()
    {
        _currentFloor--;
    }

    // 오답일 때 호출: 가차 없이 다시 시작 층수(10층)로 쫓아냅니다.
    public void ResetToStartFloor()
    {
        _currentFloor = _startFloor;
    }

    // 현재 1층에 도달했는지 확인하는 기능 (클리어 판정용)
    public bool IsTargetReached()
    {
        return _currentFloor <= _targetFloor;
    }
}