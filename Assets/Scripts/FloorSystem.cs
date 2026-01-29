using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSystem : MonoBehaviour
{
    [SerializeField] private int _startFloor = 10; // 시작 층수
    private int _currentFloor;                    // 현재 층수

    // 외부에서 현재 층 확인용
    public int CurrentFloor => _currentFloor;

    // 시작 층수 설정
    public void SetStartFloor(int startFloor)
    {
        _startFloor = startFloor;
    }

    // 게임 시작 시 1회 호출
    public void InitializeFloorSystem()
    {
        _currentFloor = _startFloor;
    }

    // 정답 선택 시 호출: 한 층 하강
    public void GoDownOneFloor()
    {
        _currentFloor--;
    }

    // 오답 선택 시 호출: 시작 층으로 리셋
    public void ResetToStartFloor()
    {
        _currentFloor = _startFloor;
    }
}
