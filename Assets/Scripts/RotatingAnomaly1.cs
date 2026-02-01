using UnityEngine;

public class RotatingAnomaly : AnomalyBase
{
    [Header("회전 설정")]
    [SerializeField] private Vector3 _rotationAxis = Vector3.up;
    [SerializeField] private float _rotationSpeed = 100f;

    private Quaternion _initialRotation;

    private void Awake()
    {
        _initialRotation = transform.rotation;
    }

    protected override void OnAnomalyStart()
    {
        
    }

    protected override void OnAnomalyEnd()
    {
        transform.rotation = _initialRotation;
    }

    private void Update()
    {
        if (_isActive)
        {
            transform.Rotate(_rotationAxis * _rotationSpeed * Time.deltaTime);
        }
    }
}