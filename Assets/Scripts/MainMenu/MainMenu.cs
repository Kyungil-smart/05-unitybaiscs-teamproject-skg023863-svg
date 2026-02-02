using UnityEngine;
using UnityEngine.SceneManagement;
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
        Init();
        if (_uiAudioSource == null) _uiAudioSource = GetComponent<AudioSource>();
    }

    private void Init()
    {
        if (_mainPanel != null) _mainPanel.SetActive(true);
        if (_optionsPanel != null) _optionsPanel.SetActive(false);

        if (_volumeSlider != null)
        {
            _volumeSlider.minValue = 0.0001f;
            _volumeSlider.maxValue = 1.0f;
            _volumeSlider.value = 1.0f;
            _volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    private void PlayClickSound()
    {
        if (_uiAudioSource != null && _clickSound != null)
        {
            _uiAudioSource.PlayOneShot(_clickSound, clickVolume);
        }
    }

    public void OnClickStartGameButton()
    {
        PlayClickSound();
        SceneManager.LoadScene("MainScene");
    }
    
    public void OnClickCreditsButton()
    {
        PlayClickSound();
        SceneManager.LoadScene("CreditScene");
    }

    public void OnClickOptionsButton()
    {
        PlayClickSound();
        if (_mainPanel != null) _mainPanel.SetActive(false);
        if (_optionsPanel != null) _optionsPanel.SetActive(true);
    }

    public void OnClickCloseOptionsButton()
    {
        PlayClickSound();
        if (_optionsPanel != null) _optionsPanel.SetActive(false);
        if (_mainPanel != null) _mainPanel.SetActive(true);
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
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMasterVolume(volume);
        }
    }
}