using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("마스터 믹서 연결")]
    public AudioMixer masterMixer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMasterVolume(float sliderValue)
    {
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20);
    }
}