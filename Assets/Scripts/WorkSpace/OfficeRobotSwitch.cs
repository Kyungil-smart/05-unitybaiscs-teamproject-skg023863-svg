using UnityEngine;

public class OfficeRobotSwitch : AnomalyBase
{
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SetChildrenActive(false);
    }

    private void SetChildrenActive(bool isActive)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(isActive);
        }
    }
    
    protected override void OnAnomalyStart()
    {
        SetChildrenActive(true);
    }

    protected override void OnAnomalyEnd()
    {
        SetChildrenActive(false);
    }
}
