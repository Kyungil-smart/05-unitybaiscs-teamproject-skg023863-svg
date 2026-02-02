using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
