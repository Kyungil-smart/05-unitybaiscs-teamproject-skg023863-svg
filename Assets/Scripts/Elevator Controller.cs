using TMPro;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    
    private Animator _animator;

    private bool isFirst;
    bool isOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        isOpen = false;
        isFirst = true;
    }

    /// <summary>
    /// 층 전환시 호출되어야할 함수
    /// </summary>
    /// <param name="floor">층 수 입력</param>
    public void SetFloorText(int floor)
    {
        _textMeshPro.SetText(floor.ToString());
    }

    private void IsOpen()
    {
        isOpen = true;
    }

    /// <summary>
    /// 만약 버튼이외에서 제어가 필요할 경우 호출할 수 있지만, 가급적 호출 지양
    /// </summary>
    public void ElevatorSequense()
    {
        if (isFirst)
        {
            _animator.Play("DoorOpen");
            isFirst = false;
        }
        else if (isOpen)
        {
            isOpen = false;
            _animator.Play("DoorClose");
        }
    }
}
