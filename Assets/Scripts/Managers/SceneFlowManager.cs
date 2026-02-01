using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Title = 0,
    Credit = 1,
    Game = 2,
    Ending = 3
}

public class SceneFlowManager : MonoBehaviour
{
    public void LoadScene(SceneType scene)
    {
        SceneManager.LoadScene((int)scene);
    }

    public void LoadTitle() => LoadScene(SceneType.Title);
    
    public void LoadCredit() => LoadScene(SceneType.Credit);
    
    public void LoadGame() => LoadScene(SceneType.Game);
    
    public void LoadEnding() => LoadScene(SceneType.Ending);
}