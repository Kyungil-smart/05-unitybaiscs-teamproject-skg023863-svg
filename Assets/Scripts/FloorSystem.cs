using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
층수 관리 전담 시스템

역할
- 현재 층수 값을 보관
- 시작 층수 기준 유지
- 층수 감소 / 리셋 처리

하지 않는 것
- 판정 로직
- 게임 클리어 판단
- UI 표시
*/
public class FloorSystem : MonoBehaviour
{
    [SerializeField] private int _startFloor = 10; // 게임 시작 시 기준 층수
    private int _currentFloor;                    // 현재 플레이 중인 층수

    // 외부에서 현재 층수 조회용
    public int CurrentFloor => _currentFloor;

    /*
    게임 시작 시 1회 호출
    - 시작 층수로 현재 층수 초기화
    */
    public void InitializeFloorSystem()
    {
        _currentFloor = _startFloor;
    }

    /*
    플레이어 선택이 정답일 때 호출
    - 한 층 아래로 이동한 것으로 처리
    */
    public void GoDownOneFloor()
    {
        _currentFloor--;
    }

    /*
    플레이어 선택이 오답일 때 호출
    - 처음 시작 층으로 되돌림
    */
    public void ResetToStartFloor()
    {
        _currentFloor = _startFloor;
    }
}