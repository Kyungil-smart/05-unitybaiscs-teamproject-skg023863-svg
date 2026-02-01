using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("오디오 믹서")]
    [SerializeField] private AudioMixer _audioMixer;

    [Header("오디오 소스 연결")]
    [SerializeField] private AudioSource _sfxSource;      
    [SerializeField] private AudioSource _movementSource; 

    [Header("오디오 클립 등록")]
    [SerializeField] private AudioClip _buttonClip;       
    [SerializeField] private AudioClip _arrivalClip;      
    [SerializeField] private AudioClip _elevatorMoveClip; 
    [SerializeField] private AudioClip _doorSoundClip;    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void PlayButtonSound() { if (_buttonClip) _sfxSource.PlayOneShot(_buttonClip); }
    public void PlayArrivalSound() { if (_arrivalClip) _sfxSource.PlayOneShot(_arrivalClip); }
    public void PlayDoorSound() { if (_doorSoundClip) _sfxSource.PlayOneShot(_doorSoundClip); }
    
    public void SetElevatorMoveSound(bool isPlaying)
    {
        if (isPlaying)
        {
            _movementSource.clip = _elevatorMoveClip;
            _movementSource.loop = true;
            _movementSource.Play();
        }
        else _movementSource.Stop();
    }

    public void SetMasterVolume(float sliderValue)
    {
        float volume = Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
        _audioMixer.SetFloat("MasterVolume", volume);
    }
}