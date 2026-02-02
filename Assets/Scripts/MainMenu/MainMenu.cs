using UnityEngine;

using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    
    [Header("패널")] 
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _optionsPanel;
    
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        // 시작 시 메인패널 ON / 옵션 패널 OFF
        if (_mainPanel != null) _mainPanel.SetActive(true);
        if (_optionsPanel != null) _optionsPanel.SetActive(false);
    }
    
    public void OnClickStartGameButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void OnClickCreditsButton()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void OnClickOptionsButton()
    {
        Debug.Log("OnclickOptions");
        // 옵션창 열기
        if (_mainPanel != null) _mainPanel.SetActive(false);
        if (_optionsPanel != null) _optionsPanel.SetActive(true);
    }
    
    public void OnClickCloseOptionsButton()
    {
        Debug.Log("OnclickCloseOptions");
        if (_mainPanel != null) _mainPanel.SetActive(true);
        if (_optionsPanel != null) _optionsPanel.SetActive(false);
    }
    
    
    public void OnClickQuitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        
    }
}
