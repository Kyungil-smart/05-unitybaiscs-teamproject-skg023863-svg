using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FloorSystem _floorSystem;
    [SerializeField] private AnomalyManager _anomalyManager;
    [SerializeField] private SceneFlowManager _sceneFlowManager;

    [Header("Settings")]
    [SerializeField, Tooltip("엘리베이터 이동 연출 시간(초)")]
    private float _elevatorTravelTime = 3.0f;

    [SerializeField, Tooltip("게임 시작 층")]
    private int _startFloor = 10;

    [SerializeField, Tooltip("연속 정답 횟수")]
    private int _streakToClear = 3;

    private int _currentStreak = 0;   // 연속 정답 카운트
    private bool _isGameCleared = false;

    // 게임 시작 시 초기화
    private void Start()
    {
        // _floorSystem.SetStartFloor(_startFloor); // 시작 층 설정

        // _floorSystem.InitializeFloorSystem(); // 현재 층을 시작 층으로 초기화

        _anomalyManager.PrepareAnomalySection(); // 첫 층 이상현상 준비 → 첫 판은 정상 판
    }

    /*
	엘리베이터 버튼 진입점
	- Up / Down 버튼 클릭 시 호출
	@param playerChoice : 플레이어 선택 값
	*/
    public void OnPlayerChoice(PlayerChoice playerChoice)
    {
        if (_isGameCleared) return;

        StartCoroutine(HandleElevatorSequence(playerChoice)); // 선택 처리 코루틴 시작
    }

    /*
	엘리베이터 이동 + 선택 처리
	- 이동 대기
	- 정답/오답 판정 후 층수 조정
	- 연속 정답 달성 시 게임 클리어
	*/
    private IEnumerator HandleElevatorSequence(PlayerChoice playerChoice)
    {
        // 버튼 클릭 + 이동 사운드 재생
        AudioManager.Instance.PlayButtonSound();
        AudioManager.Instance.SetElevatorMoveSound(true);

        yield return new WaitForSeconds(_elevatorTravelTime); // 엘리베이터 이동 연출 대기

        AudioManager.Instance.SetElevatorMoveSound(false); // 이동 종료

        bool isCorrect = _anomalyManager.IsPlayerChoiceCorrect(playerChoice); // 선택 판정

        if (isCorrect)
        {
            // 정답: 한 층 하강 + 연속 정답 증가
            _floorSystem.GoDownOneFloor();
            _currentStreak++;
        }
        else
        {
            // 오답: 시작 층으로 리셋 + 연속 정답 초기화
            _floorSystem.ResetToStartFloor();
            _currentStreak = 0;
        }

        // 층 도착 사운드 재생
        AudioManager.Instance.PlayArrivalSound();

        // 연속 정답 달성 시 게임 클리어 처리
        if (_currentStreak >= _streakToClear)
        {
            HandleGameClear();
            yield break;
        }

        // 다음 층 이상현상 준비
        _anomalyManager.PrepareAnomalySection();
    }

    // 게임 클리어 처리
    private void HandleGameClear()
    {
        _isGameCleared = true;

        if (_sceneFlowManager != null)
        {
            _sceneFlowManager.LoadCredit();
        }
    }
}