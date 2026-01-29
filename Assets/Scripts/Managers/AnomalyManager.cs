using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    [Header("설정")]
    [SerializeField, Range(0f, 1f), Tooltip("한 층 이상현상 등장 확률")]
    private float _anomalySpawnChance = 0.5f;

    [SerializeField, Tooltip("이상현상 프리팹 목록")]
    private GameObject[] _anomalyPrefabs;

    private bool _isAnomalyActive;
    private IAnomaly _currentAnomaly;
    private GameObject _currentAnomalyObject;
    private bool _isFirstRound = false; // 첫 판 여부

    // 다음 층 준비
    public void PrepareAnomalySection()
    {
        // 이전 이상현상 비활성화
        if (_currentAnomalyObject != null)
            _currentAnomalyObject.SetActive(false);

        _currentAnomaly = null;
        _currentAnomalyObject = null;

        // 첫 판이면 정상 판 처리
        if (_isFirstRound)
        {
            _isAnomalyActive = false;
            _isFirstRound = false; // 다음 판부터 랜덤 적용
            return;
        }

        // 이후 판: 랜덤 등장
        _isAnomalyActive = Random.value < _anomalySpawnChance;

        if (_isAnomalyActive && _anomalyPrefabs.Length > 0)
        {
            _currentAnomalyObject = _anomalyPrefabs[Random.Range(0, _anomalyPrefabs.Length)];
            _currentAnomaly = _currentAnomalyObject.GetComponent<IAnomaly>();
            _currentAnomalyObject.SetActive(true);
        }
    }

    // 플레이어 선택 판정
    public bool IsPlayerChoiceCorrect(PlayerChoice playerChoice)
    {
        if (!_isAnomalyActive) return playerChoice == PlayerChoice.Down;
        if (_currentAnomaly == null) return playerChoice == PlayerChoice.Down;
        return _currentAnomaly.IsChoiceCorrect(playerChoice);
    }
}