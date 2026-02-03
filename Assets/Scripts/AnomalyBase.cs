using UnityEngine;

public abstract class AnomalyBase : MonoBehaviour, IAnomaly
{
    protected bool _isActive;

    public void Enter()
    {
        _isActive = true;
        OnAnomalyStart(); 
    }

    public void Exit()
    {
        _isActive = false;
        OnAnomalyEnd();
    }

    public bool IsChoiceCorrect(PlayerChoice playerChoice)
    {
        if (_isActive) return playerChoice == PlayerChoice.Up;
        return playerChoice == PlayerChoice.Down;
    }

    protected virtual void OnAnomalyStart() { }
    protected virtual void OnAnomalyEnd() { }
}