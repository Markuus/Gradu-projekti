﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject gameManager;
    private GameplayData gameplayData;
    public GameObject player;
    private PlayerHealth playerHealth;
    private CoinSystem coinSystem;
    private int pauseCounter = -1;

    private void Awake()
    {
        coinSystem = gameManager.GetComponent<CoinSystem>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        gameplayData = gameManager.GetComponent<GameplayData>();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseCounter += 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        coinSystem.SetCoinsTotal(0);
        Time.timeScale = 1f;
    }

    public void Respawn()
    {
        Time.timeScale = 1f;
        playerHealth.ResPawn();
    }

    public void GoToMenu()
    {
        //TALLENNA DATA TÄSSÄ
        //gameplayData.SendDataToGoogleForms();
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public int GetPauseCounter()
    {
        return pauseCounter;
    }
    
}
