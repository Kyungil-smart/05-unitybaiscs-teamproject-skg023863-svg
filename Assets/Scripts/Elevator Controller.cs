using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _elevDoorSound;
    [SerializeField][Range(0,1)] private float _soundVolum;
    
    private Animator _animator;

    private bool isFirst;
    bool isOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
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

    private void ElevDoorSound()
    {
        _audioSource.PlayOneShot(_elevDoorSound, _soundVolum);
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
