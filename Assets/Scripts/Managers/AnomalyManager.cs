using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
이상현상 관리 매니저

역할
- 층(섹션)마다 이상현상 생성 여부 결정
- 이상현상 프리팹 생성 / 제거
- 플레이어 선택에 대한 판정 위임

하지 않는 것
- 층수 변경
- 게임 클리어 판단
- 사운드 처리
*/
public class AnomalyManager : MonoBehaviour
{
    [Header("이상현상 설정")]
    [SerializeField] private float _anomalySpawnChance = 0.5f; // 이상현상 등장 확률
    [SerializeField] private GameObject[] _anomalyPrefabs;     // 사용 가능한 이상현상 목록
    [SerializeField] private Transform _spawnPoint;            // 엘리베이터 기준 생성 위치

    private bool _isAnomalyActive;              // 현재 층에 이상현상이 있는지 여부
    private IAnomaly _currentAnomaly;            // 현재 활성화된 이상현상 로직
    private GameObject _currentAnomalyObject;   // 실제 생성된 프리팹 오브젝트

    /*
    다음 층(섹션) 진입 전 호출

    흐름
    1. 이전 층의 이상현상 제거
    2. 이번 층에 이상현상 등장 여부 랜덤 결정
    3. 등장한다면 프리팹 생성 및 IAnomaly 참조 확보
    */
    public void PrepareAnomalySection()
    {
        // 이전 이상현상 제거
        if (_currentAnomalyObject != null)
        {
            Destroy(_currentAnomalyObject);
        }

        _currentAnomaly = null;
        _currentAnomalyObject = null;

        // 이상현상 등장 여부 결정
        _isAnomalyActive = Random.value < _anomalySpawnChance;

        // 이상현상 생성
        if (_isAnomalyActive && _anomalyPrefabs.Length > 0)
        {
            GameObject prefab =
                _anomalyPrefabs[Random.Range(0, _anomalyPrefabs.Length)];

            _currentAnomalyObject =
                Instantiate(prefab, _spawnPoint.position, _spawnPoint.rotation);

            // 이상현상 판정 로직 참조
            _currentAnomaly =
                _currentAnomalyObject.GetComponent<IAnomaly>();
        }
    }

    /*
    플레이어 선택 판정

    규칙
    - 이상현상 없음  → Down 선택이 정답
    - 이상현상 있음  → 이상현상 프리팹 로직에 따라 판정
    */
    public bool IsPlayerChoiceCorrect(PlayerChoice playerChoice)
    {
        // 이상현상이 없는 정상 층
        if (!_isAnomalyActive)
        {
            return playerChoice == PlayerChoice.Down;
        }

        // 이상현상은 있는데 로직이 없을 경우 안전 처리
        if (_currentAnomaly == null)
        {
            return playerChoice == PlayerChoice.Down;
        }

        // 이상현상 로직에 판정 위임
        return _currentAnomaly.IsChoiceCorrect(playerChoice);
    }
}