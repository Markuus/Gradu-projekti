using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject mainmenuPanel;
    public GameObject optionsPanel;
    private void Awake()
    {
        mainmenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void PlayGame1()
    {
        SceneManager.LoadScene("Game_Joystick");
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene("Game_TouchToMove");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
