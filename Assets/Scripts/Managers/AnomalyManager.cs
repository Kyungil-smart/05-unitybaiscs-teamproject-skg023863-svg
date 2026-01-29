using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    [Header("확률 설정")]
    [SerializeField, Range(0, 1)] private float _anomalySpawnChance = 0.5f;

    [Header("사무실 내 이변 오브젝트 리스트")]
    [SerializeField] private GameObject[] _anomalyObjects; // 씬에 배치된 이변들 드래그

    private bool _isAnomalyActive;
    private IAnomaly _currentAnomaly;

    // forceNormal: true면 확률 무시하고 무조건 정상 방 생성 (튜토리얼용)
    public void PrepareAnomalySection(bool forceNormal = false)
    {
        // 이전 이변 정리 (정상 물체 복구)
        if (_currentAnomaly != null)
        {
            _currentAnomaly.DeactivateAnomaly();
        }

        // 모든 이변 오브젝트 끄기 (초기화)
        foreach (var obj in _anomalyObjects)
        {
            if (obj != null) obj.SetActive(false);
        }

        _currentAnomaly = null;

        // 이변 등장 여부 결정
        // forceNormal이 true면 무조건 이변 없음(false)
        _isAnomalyActive = !forceNormal && (Random.value < _anomalySpawnChance);

        if (_isAnomalyActive && _anomalyObjects.Length > 0)
        {
            // 랜덤 이변 선택 및 활성화
            GameObject selected = _anomalyObjects[Random.Range(0, _anomalyObjects.Length)];
            selected.SetActive(true);

            _currentAnomaly = selected.GetComponent<IAnomaly>();

            // 교체 로직 실행 (정상 물체 끄기)
            if (_currentAnomaly != null)
            {
                _currentAnomaly.ActivateAnomaly();
            }
        }
    }

    public bool IsPlayerChoiceCorrect(PlayerChoice playerChoice)
    {
        // 이변 없음 -> Down이 정답
        if (!_isAnomalyActive) return playerChoice == PlayerChoice.Down;

        // 안전장치
        if (_currentAnomaly == null) return playerChoice == PlayerChoice.Down;

        // 이변 있음 -> 이변의 로직에 따름
        return _currentAnomaly.IsChoiceCorrect(playerChoice);
    }
}