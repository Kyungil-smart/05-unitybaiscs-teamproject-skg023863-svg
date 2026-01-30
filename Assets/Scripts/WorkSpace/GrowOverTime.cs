using UnityEngine;

public class GrowOverTime : MonoBehaviour
{
    [Header("초당 성장")]
    [SerializeField] private Vector3 _scalePerSecond = new Vector3(0.01f, 0.01f, 0.01f);
    
    [Header("최대 크기 제한")]
    [SerializeField] private Vector3 _maxScale = new Vector3(10f, 7f, 10f);
    
    private void Update()
    {
        ApplyGrowth(Time.deltaTime);
    }

    private void ApplyGrowth(float deltaTime)
    {
        Vector3 nextLocalScale = transform.localScale + (_scalePerSecond * deltaTime);
        
        // 최대값을 넘지 않게
        nextLocalScale = new Vector3(
            Mathf.Min(nextLocalScale.x, _maxScale.x),
            Mathf.Min(nextLocalScale.y, _maxScale.y),
            Mathf.Min(nextLocalScale.z, _maxScale.z)
        );
        
        transform.localScale = nextLocalScale;
    }
}