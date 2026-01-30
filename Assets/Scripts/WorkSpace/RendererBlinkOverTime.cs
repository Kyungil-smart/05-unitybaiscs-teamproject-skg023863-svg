using System.Collections;
using UnityEngine;

public class RendererBlinkOverTime : MonoBehaviour
{
    [SerializeField] private float _Seconds = 2f;
    
    private Renderer _renderer;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        if (_renderer != null && _Seconds > 0f)
        {
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            _renderer.enabled = !_renderer.enabled;
            yield return new WaitForSeconds(_Seconds);  // n초 대기
        }
    }
}
