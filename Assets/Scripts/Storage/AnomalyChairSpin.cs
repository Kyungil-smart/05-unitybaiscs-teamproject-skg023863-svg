using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyChairSpin : AnomalyBase
{
    [SerializeField] [Range(0, 1000)]private float _SpinSpeed = 1000f;
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    private bool _isSpin;

    void Awake()
    {
        _isSpin = false;
        _originalPosition = transform.position;
        _originalRotation = transform.rotation;
    }
    
    protected override void OnAnomalyStart()
    {
        _isSpin = true;
        ChairSpin();
    }

    protected override void OnAnomalyEnd()
    {
        _isSpin = false;
        transform.position = _originalPosition;
        transform.rotation = _originalRotation;
    }
    
    private void ChairSpin()
    {
        if (_isSpin)
        {
            transform.Rotate(Vector3.up * _SpinSpeed * Time.deltaTime);
        }
    }
}
