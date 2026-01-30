using UnityEngine;

public abstract class AnomalyBase : MonoBehaviour, IAnomaly
{
    [SerializeField]
    protected GameObject _normalObject;

    protected bool _isActive;

    public virtual void Enter()
    {
        _isActive = true;

        if (_normalObject != null)
        {
            _normalObject.SetActive(false);
        }
    }

    public virtual void Exit()
    {
        _isActive = false;

        if (_normalObject != null)
        {
            _normalObject.SetActive(true);
        }
    }

    public virtual bool IsChoiceCorrect(PlayerChoice playerChoice)
    {
        if (_isActive)
        {
            return playerChoice == PlayerChoice.Up;
        }

        return playerChoice == PlayerChoice.Down;
    }
}