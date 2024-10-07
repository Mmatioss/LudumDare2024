using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private GameObject _defeatScreen;

    public void PauseGame()
    {
        if (Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
        }
        else { Time.timeScale = 1f; }
    }

    public void GameOver()
    {
        _defeatScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Victory()
    {
        _victoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
