using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("매니저 연결")]
    [SerializeField] private FloorSystem _floorSystem;
    [SerializeField] private AnomalyManager _anomalyManager;
    [SerializeField] private SceneFlowManager _sceneFlowManager;

    [Header("설정")]
    [SerializeField] private float _elevatorTravelTime = 3.0f;

    private bool _isBusy;         // 중복 입력 방지
    private bool _isFirstSection; // 첫 판 여부 (튜토리얼)

    private void Start()
    {
        _isFirstSection = true;
        _floorSystem.InitializeFloorSystem();

        // 첫 시작은 무조건 정상 방 (튜토리얼)
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

        // 이동 시작 (소리 ON)
        AudioManager.Instance.PlayButtonSound();
        AudioManager.Instance.SetElevatorMoveSound(true);

        // 이동 중에 '다음 방'을 미리 준비 (이제부터 랜덤)
        _anomalyManager.PrepareAnomalySection(false);

        // 엘리베이터 이동 시간 대기
        yield return new WaitForSeconds(_elevatorTravelTime);

        // 도착 (소리 OFF, 땡!)
        AudioManager.Instance.SetElevatorMoveSound(false);
        AudioManager.Instance.PlayArrivalSound();

        // 판정 로직
        if (_isFirstSection)
        {
            // 첫 판은 맞든 틀리든 카운트 하지 않음
            _isFirstSection = false;
            Debug.Log("튜토리얼 종료. 이제부터 게임이 시작됩니다.");
        }
        else
        {
            // 실제 게임 판정
            bool isCorrect = _anomalyManager.IsPlayerChoiceCorrect(playerChoice);

            if (isCorrect)
            {
                _floorSystem.GoDownOneFloor();
                Debug.Log($"정답! 현재 층: {_floorSystem.CurrentFloor}");
            }
            else
            {
                _floorSystem.ResetToStartFloor();
                Debug.Log("오답! 처음으로 돌아갑니다.");
            }
        }

        // 클리어 체크 (0층 도달 시)
        if (_floorSystem.CurrentFloor <= 0)
        {
            Debug.Log("Game Clear!");
            if (_sceneFlowManager != null) _sceneFlowManager.LoadCredit();
        }

        _isBusy = false;
    }
}