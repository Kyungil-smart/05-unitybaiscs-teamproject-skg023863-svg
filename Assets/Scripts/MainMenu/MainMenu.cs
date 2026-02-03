using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("패널 연결")] 
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private Slider _volumeSlider;

    [Header("오디오 설정 (직접 재생)")]
    [SerializeField] private AudioSource _uiAudioSource;
    [SerializeField] private AudioClip _clickSound;
    [Range(0f, 1f)] public float clickVolume = 1f;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        Init();
        _uiAudioSource = GetComponent<AudioSource>();
    }

    private void Init()
    {
        _mainPanel.SetActive(true);
        _optionsPanel.SetActive(false);

        _volumeSlider.minValue = 0.0001f;
        _volumeSlider.maxValue = 1.0f;
        _volumeSlider.value = 1.0f;
        _volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void PlayClickSound()
    {
        _uiAudioSource.PlayOneShot(_clickSound, clickVolume);
    }

    public void OnClickStartGameButton()
    {
        PlayClickSound();
        SceneFlowManager.Instance.LoadGame();
    }
    
    public void OnClickCreditsButton()
    {
        PlayClickSound();
        SceneFlowManager.Instance.LoadCredit();
    }

    public void OnClickOptionsButton()
    {
        PlayClickSound();
        _mainPanel.SetActive(false);
        _optionsPanel.SetActive(true);
    }

    public void OnClickCloseOptionsButton()
    {
        PlayClickSound();
        _optionsPanel.SetActive(false);
        _mainPanel.SetActive(true);
    }
    
    public void OnClickQuitGameButton()
    {
        PlayClickSound();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SetVolume(float volume)
    {
        AudioManager.Instance.SetMasterVolume(volume);
    }
}