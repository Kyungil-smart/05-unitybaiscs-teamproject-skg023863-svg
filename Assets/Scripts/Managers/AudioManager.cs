using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _movementSource;

    [Header("Clips")]
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