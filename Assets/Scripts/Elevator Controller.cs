using TMPro;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private TextMeshProUGUI _textMeshPro;

    bool isClose;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        isClose = _animator.GetBool("isClose");
    }

    /// <summary>
    /// 층 전환시 호출되어야할 함수
    /// </summary>
    /// <param name="floor">층 수 입력</param>
    public void SetFloorText(int floor)
    {
        _textMeshPro.SetText(floor.ToString());
    }

    /// <summary>
    /// 만약 버튼이외에서 제어가 필요할 경우 호출할 수 있지만, 가급적 호출 지양
    /// </summary>
    public void ElevatorSequense()
    {
        // 엘리베이터의 모든 애니메이션의 길이는 1.0 이기 때문에 하드 코딩
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (isClose)
            {
                _animator.SetBool("isClose", false);
                isClose = false;
            }
            else
            {
                _animator.SetBool("isClose", true);
                isClose = true;
            }
        }
    }
}
