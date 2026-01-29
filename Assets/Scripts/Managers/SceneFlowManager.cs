using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    // 타이틀 화면 이동
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    // 게임 시작
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    // 게임 클리어 후 크레딧 이동
    public void LoadCredit()
    {
        SceneManager.LoadScene("Credit");
    }
}