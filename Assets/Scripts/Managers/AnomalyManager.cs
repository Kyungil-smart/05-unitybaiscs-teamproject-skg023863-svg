using UnityEngine;
using System.Linq;

public class AnomalyManager : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _anomalySpawnChance = 0.5f;
    [SerializeField] private MonoBehaviour[] _anomalyScripts;

    private IAnomaly[] _anomalies;
    private IAnomaly _currentAnomaly;
    private bool _isAnomalyActive;

    private void Awake()
    {
        _anomalies = _anomalyScripts.OfType<IAnomaly>().ToArray();
        foreach (var a in _anomalies) a.Exit();
    }

    public void PrepareAnomalySection(bool isForceNormal)
    {
        if (_currentAnomaly != null)
        {
            _currentAnomaly.Exit();
            _currentAnomaly = null;
        }

        _isAnomalyActive = false;

        if (isForceNormal || Random.value >= _anomalySpawnChance || _anomalies.Length == 0) return;

        _currentAnomaly = _anomalies[Random.Range(0, _anomalies.Length)];
        _currentAnomaly.Enter();
        _isAnomalyActive = true;
    }

    public bool IsPlayerChoiceCorrect(PlayerChoice playerChoice)
    {
        if (!_isAnomalyActive || _currentAnomaly == null)
            return playerChoice == PlayerChoice.Down;

        return _currentAnomaly.IsChoiceCorrect(playerChoice);
    }
}