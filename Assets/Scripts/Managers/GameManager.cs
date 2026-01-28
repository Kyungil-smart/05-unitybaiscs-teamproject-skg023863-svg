using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
게임 전체 규칙 관리자 (컨트롤 타워)

역할
- 플레이어 선택 흐름 제어
- 엘리베이터 이동 연출 타이밍 관리
- 이상현상 판정 결과 처리
- 층수 변경
- 게임 클리어 판단 및 씬 전환

중요
- 실제 이동 연출은 엘리베이터 연출
- 이 클래스는 "논리 흐름"만 담당
*/
public class GameManager : MonoBehaviour
{
	[SerializeField] private AnomalyManager _anomalyManager; // 이상현상 담당
	[SerializeField] private FloorSystem _floorSystem;       // 층수 담당
	[SerializeField] private float _elevatorTravelTime = 3.0f; // 이동 연출 시간

	private bool _isGameCleared; // 중복 입력 방지용 플래그

	private void Start()
	{
		_isGameCleared = false;

		// 게임 시작 시 층수 초기화
		_floorSystem.InitializeFloorSystem();

		// 첫 판은 정상 섹션으로 시작
		_anomalyManager.PrepareAnomalySection();
	}

	/*
	UI 버튼에서 호출
	- 플레이어가 Up / Down 선택 시 진입점
	*/
	public void OnPlayerChoice(PlayerChoice playerChoice)
	{
		// 이미 클리어 상태면 입력 무시
		if (_isGameCleared)
		{
			return;
		}

		StartCoroutine(HandleElevatorSequence(playerChoice));
	}

	/*
	엘리베이터 이동 + 판정 전체 흐름

	이 코루틴은 "이동을 시킨다"기보다는
	- 이동이 끝났다고 가정한 후
	- 그 결과를 처리하는 논리 흐름임
	*/
	private IEnumerator HandleElevatorSequence(PlayerChoice playerChoice)
	{
		// 버튼 클릭음 + 이동 시작음
		AudioManager.Instance.PlayButtonSound();
		AudioManager.Instance.SetElevatorMoveSound(true);

		// 엘리베이터 이동 연출 대기
		yield return new WaitForSeconds(_elevatorTravelTime);

		// 이동 종료
		AudioManager.Instance.SetElevatorMoveSound(false);

		// 플레이어 선택 판정
		bool isChoiceCorrect =
			_anomalyManager.IsPlayerChoiceCorrect(playerChoice);

		// 판정 결과에 따른 층수 처리
		if (isChoiceCorrect)
		{
			_floorSystem.GoDownOneFloor();
		}
		else
		{
			_floorSystem.ResetToStartFloor();
		}

		// 도착 효과음
		AudioManager.Instance.PlayArrivalSound();

		// 게임 클리어 조건 확인
		if (_floorSystem.CurrentFloor <= 1)
		{
			HandleGameClear();
			yield break;
		}

		// 다음 층 이상현상 준비
		_anomalyManager.PrepareAnomalySection();
	}

	/*
	게임 클리어 처리

	- 입력 차단
	- 크레딧 씬 이동
	*/
	private void HandleGameClear()
	{
		_isGameCleared = true;

		SceneFlowManager sceneFlowManager =
			FindObjectOfType<SceneFlowManager>();

		if (sceneFlowManager != null)
		{
			sceneFlowManager.LoadCredit();
		}
	}
}