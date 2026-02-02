using UnityEngine;

public class MemeSwitch_01 : AnomalyBase
{
    [SerializeField] private GameObject _targetObject;

    private void Awake()
    {
        _targetObject.SetActive(false);
    }

    protected override void OnAnomalyStart()
    {
        _targetObject.SetActive(true);
    }

    protected override void OnAnomalyEnd()
    {
        _targetObject.SetActive(false);
    }
}
