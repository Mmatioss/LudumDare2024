using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    void PlayLv1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    void PlayLv2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }

    void Exit()
    {
        Application.Quit();
    }

    void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
