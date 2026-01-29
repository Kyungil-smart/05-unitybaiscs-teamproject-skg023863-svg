using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingAnomaly : AnomalyBase
{
    [Header("회전 설정")]
    [SerializeField] private Vector3 _rotationAxis = Vector3.up;
    [SerializeField] private float _rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(_rotationAxis * _rotationSpeed * Time.deltaTime);
    }
}