using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnClickStartGame()
    {
        Debug.Log("OnclickStartGame");
    }
    

    public void OnClickCredits()
    {
        Debug.Log("OnclickCredits");
    }

    public void OnClickOptions()
    {
        Debug.Log("OnclickOptions");
    }
    
    public void OnClickQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        
    }
}
