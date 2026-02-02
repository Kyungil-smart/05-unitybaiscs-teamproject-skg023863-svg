using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyChairSpin : AnomalyBase
{
    [SerializeField] [Range(0, 1000)]private float _SpinSpeed = 1000f;
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;

    void Awake()
    {
        _originalPosition = transform.localPosition;
        _originalRotation = transform.localRotation;
    }
    
    protected override void OnAnomalyStart()
    {
        
    }

    protected override void OnAnomalyEnd()
    {
        transform.localPosition = _originalPosition;
        transform.localRotation = _originalRotation;
    }
    
    private void ChairSpin()
    {
        if (_isActive)
        {
            transform.Rotate(Vector3.forward * _SpinSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        ChairSpin();
    }
    
}
