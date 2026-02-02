using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeRobotSwitch : AnomalyBase
{
    [Header("타겟 오브젝트")]
    [SerializeField] private List<GameObject> targetChildObjects = new List<GameObject>();
    
    
    
    
    
    
    protected override void OnAnomalyStart()
    {
    }

    protected override void OnAnomalyEnd()
    {
        
    }
}
