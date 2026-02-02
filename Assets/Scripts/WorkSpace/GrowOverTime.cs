using System;
using System.Collections;
using UnityEngine;

public class GrowOverTime : AnomalyBase
{
    [Header("초당 성장")] [SerializeField] private Vector3 _scalePerSecond = new Vector3(0.01f, 0.01f, 0.01f);

    [Header("최대 크기 제한")] [SerializeField] private Vector3 _maxScale = new Vector3(10f, 7f, 10f);

    private Coroutine _growthCoroutine;
    private Vector3 _originalLocalScale;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _originalLocalScale = transform.localScale;
    }

    private IEnumerator Grow()
    {
        while (true)
        {
            Vector3 currentLocalScale = transform.localScale;
            Vector3 nextLocalScale = currentLocalScale + (_scalePerSecond * Time.deltaTime);

            // 최대값을 넘지 않게
            nextLocalScale = new Vector3(
                Mathf.Min(nextLocalScale.x, _maxScale.x),
                Mathf.Min(nextLocalScale.y, _maxScale.y),
                Mathf.Min(nextLocalScale.z, _maxScale.z)
            );

            transform.localScale = nextLocalScale;

            yield return null;
        }
    }

    protected override void OnAnomalyStart()
    {
        if (_growthCoroutine != null) return;
        
        _growthCoroutine = StartCoroutine(Grow());
    }

    protected override void OnAnomalyEnd()
    {
        if (_growthCoroutine != null)
        {
            StopCoroutine(_growthCoroutine);
            _growthCoroutine = null;
        }

        // 스케일 복구
        transform.localScale = _originalLocalScale;
    }
}