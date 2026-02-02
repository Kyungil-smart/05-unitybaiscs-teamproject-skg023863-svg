using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWater : MonoBehaviour
{
    protected virtual void OnAnomalyStart()
    {
        
    }

    protected virtual void OnAnomalyEnd()
    {
        gameObject.SetActive(false);
    }
}
