using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _sfxSource;       // 버튼, 도착 등 단발 효과음
    [SerializeField] private AudioSource _movementSource;  // 엘리베이터 이동 루프음

    [SerializeField] private AudioClip _buttonClip;
    [SerializeField] private AudioClip _arrivalClip;
    [SerializeField] private AudioClip _elevatorMoveClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 버튼 클릭 시 호출
    public void PlayButtonSound()
    {
        _sfxSource.PlayOneShot(_buttonClip);
    }

    // 층 도착 시 호출
    public void PlayArrivalSound()
    {
        _sfxSource.PlayOneShot(_arrivalClip);
    }

    /*
    엘리베이터 이동 중인지 여부만 전달받아
    - true  : 이동음 재생
    - false : 이동음 중지
    */
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