using UnityEngine;
using TMPro; 

public class FloorSystem : MonoBehaviour
{
    [Header("설정")]
    [SerializeField] private int _startFloor = 7;
    [SerializeField] private int _targetFloor = 0;

    [Header("사운드 설정")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _arriveSound;

    public int CurrentFloor { get; private set; }

    public void InitializeFloorSystem()
    {
        CurrentFloor = _startFloor;
        if (_audioSource == null) 
            _audioSource = GetComponent<AudioSource>();
    }

    public void GoDownOneFloor()
    {
        CurrentFloor--;
        PlayArriveSound();
    }

    public void ResetToStartFloor()
    {
        CurrentFloor = _startFloor;
        PlayArriveSound();
    }

    public bool IsTargetReached()
    {
        return CurrentFloor <= _targetFloor;
    }

    private void PlayArriveSound()
    {
        if (_audioSource != null && _arriveSound != null)
        {
            _audioSource.PlayOneShot(_arriveSound);
        }
    }
}