using UnityEngine;
//using UnityEditor.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void OnClickStartGameButton()
    {
        Debug.Log("OnclickStartGame");
    }
    
    public void OnClickCreditsButton()
    {
        //SceneManager.LoadScene("CreditScene");
        Debug.Log("OnclickCredits");
    }

    public void OnClickOptionsButton()
    {
        Debug.Log("OnclickOptions");
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
