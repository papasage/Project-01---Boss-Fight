using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public event Action PauseGame;

    void Update()
    {
        Quit();
        RestartLevel();
        Pause();
    }

    private void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Game Closed");
            Application.Quit();
        }
    }

    private void RestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Scene Reset!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseGame?.Invoke();
        } 
    }
}
