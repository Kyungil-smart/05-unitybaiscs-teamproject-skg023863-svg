using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadEnding()
    {
        SceneManager.LoadScene("Ending");
    }

    public void LoadCredit()
    {
        SceneManager.LoadScene("Credit");
    }
}