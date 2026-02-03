using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyToiletSigns : AnomalyBase
{
    private Vector3 _originalScale = new Vector3(1744.615f, 1744.615f, 1744.615f);
    

    protected override void OnAnomalyStart()
    {
        transform.localScale = new Vector3(
            _originalScale.x,
            -_originalScale.y,
            _originalScale.z
        );
    }

    protected override void OnAnomalyEnd()
    {
        transform.localScale = _originalScale;
    }
}
