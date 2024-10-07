using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void PlayLv1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void PlayLv2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
