using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    public void OnClickReplay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("LSH_MainMenu");
    }
}
