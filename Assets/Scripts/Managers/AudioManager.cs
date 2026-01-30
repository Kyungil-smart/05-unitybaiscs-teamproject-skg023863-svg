using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("오디오 소스")]
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _movementSource;

    [Header("오디오 클립")]
    [SerializeField] private AudioClip _buttonClip;
    [SerializeField] private AudioClip _arrivalClip;
    [SerializeField] private AudioClip _elevatorMoveClip;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlayButtonSound()
    {
        if (_buttonClip) _sfxSource.PlayOneShot(_buttonClip);
    }

    public void PlayArrivalSound()
    {
        if (_arrivalClip) _sfxSource.PlayOneShot(_arrivalClip);
    }

    public void SetElevatorMoveSound(bool isPlaying)
    {
        if (isPlaying)
        {
            _movementSource.clip = _elevatorMoveClip;
            _movementSource.loop = true;
            _movementSource.Play();
        }
        else
        {
            _movementSource.Stop();
        }
    }
}