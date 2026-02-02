using System.Collections;
using UnityEngine;

public class PositionShiftOverTime : AnomalyBase
{
    [Header("초당 전진 거리 Z축")] 
    [SerializeField] private float _moveSpeedPerSecond = 0.015f;

    [Header("최대 거리 Z축")]
    [SerializeField] private float _maxMoveDistance = 20f;
    
    private Coroutine _moveCoroutine;

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            float currentZ = transform.localPosition.z;
            float nextZ = currentZ + _moveSpeedPerSecond * Time.deltaTime;

            // 최대 거리면 종료 
            if (nextZ >= _maxMoveDistance)
            {
                transform.localPosition = new Vector3(0f, 0f, _maxMoveDistance);
                _moveCoroutine = null;
                yield break;
            }
            
            transform.localPosition = new Vector3(0, 0, nextZ);
            yield return null;
        }
    }

    protected override void OnAnomalyStart()
    {
        // 입구쪽으로 방향틈
        //transform.localRotation = Quaternion.Euler(-89.98f, -90f, 0f);
        
        if (_moveCoroutine != null) return;
        _moveCoroutine = StartCoroutine(MoveCoroutine());
    }

    protected override void OnAnomalyEnd()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
        
        // 위치 복구
        transform.localPosition = Vector3.zero;
    }
}
