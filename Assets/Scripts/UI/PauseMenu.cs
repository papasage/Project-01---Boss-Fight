using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenu : MonoBehaviour  
{
    [SerializeField] GameManager _gameManager = null;

    private void OnEnable()
    {
        _gameManager.PauseGame += OnPauseGame;
    }

    private void OnDisable()
    {
        _gameManager.PauseGame -= OnPauseGame;
    }

    void OnPauseGame()
    {
        Debug.Log("GAME PAUSED!");
    }
}
