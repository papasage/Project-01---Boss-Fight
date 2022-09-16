using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
     if (Input.GetKey(KeyCode.Backspace))
        {
            Debug.Log("Scene Reset!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

     if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Game Closed");
            Application.Quit();
        }
    }
}
