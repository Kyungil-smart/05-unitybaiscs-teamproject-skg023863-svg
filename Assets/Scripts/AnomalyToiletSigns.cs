using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyToiletSigns : AnomalyBase
{
    private Vector3 _originalScale;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    protected override void OnAnomalyStart()
    {
        Vector3 scale = _originalScale;
        scale.y *= -1;
        transform.localScale = scale;
    }

    protected override void OnAnomalyEnd()
    {
        transform.localScale = _originalScale;
    }
}
