using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWater : AnomalyBase
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    
    protected override void OnAnomalyStart()
    {
        gameObject.SetActive(true);
    }

    protected override void OnAnomalyEnd()
    {
        gameObject.SetActive(false);
    }
}
