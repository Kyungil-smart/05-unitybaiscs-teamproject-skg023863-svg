using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodhands : AnomalyBase
{
    protected virtual void OnAnomalyStart()
    {
        
    }

    protected virtual void OnAnomalyEnd()
    {
        gameObject.SetActive(false);
    }
}
