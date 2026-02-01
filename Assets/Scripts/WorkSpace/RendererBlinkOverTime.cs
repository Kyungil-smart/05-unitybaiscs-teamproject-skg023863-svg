using System.Collections;
using UnityEngine;

public class RendererBlinkOverTime : MonoBehaviour
{
    [SerializeField] private float _Seconds = 2f;
    
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

    private void OnEnable()
    {
        if (_renderer != null && _Seconds > 0f)
        {
            _blinkCoroutine = StartCoroutine(Blink());
        }
    }

    private void OnDisable()
    {
        // 오브젝트가 꺼질 때 코루틴 종료
        if (_blinkCoroutine != null)
        {
            StopCoroutine(_blinkCoroutine);
            _blinkCoroutine = null;
        }
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            _renderer.enabled = !_renderer.enabled;
            yield return _wait;  // n초 대기
        }
    }
}
