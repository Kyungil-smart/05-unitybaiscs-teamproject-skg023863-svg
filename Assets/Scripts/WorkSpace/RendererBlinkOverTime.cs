using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class RendererBlinkOverTime : AnomalyBase
{
    [SerializeField] [Range(0.1f, 2f)] private float _Seconds;

    private Renderer _renderer;
    private WaitForSeconds _wait;
    private Coroutine _blinkCoroutine;
    
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _renderer = GetComponent<Renderer>();
        _wait = new WaitForSeconds(_Seconds);
    }
    
    private IEnumerator Blink()
    {
        while (true)
        {
            _renderer.enabled = !_renderer.enabled;
            yield return _wait; // n초 대기
        }
    }

    protected override void OnAnomalyStart()
    {
        if (_blinkCoroutine != null) return;
        _blinkCoroutine = StartCoroutine(Blink());    
    }

    protected override void OnAnomalyEnd()
    {
        if (_blinkCoroutine != null)
        {
            StopCoroutine(_blinkCoroutine);
            _blinkCoroutine = null;
        }

        if (_renderer != null)
        {
            _renderer.enabled = true;
        }
    }
}