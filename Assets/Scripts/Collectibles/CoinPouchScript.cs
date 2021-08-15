using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinPouchScript : MonoBehaviour
{

    public GameObject player;
    private PlayerHealth playerHealthScript;
    public GameObject pouchEmpty;
    public GameObject pouchFilled;
    public Button pouchButton;
    public Button pauseButton;
    public GameObject winPanel;
    public GameObject pouchPanel;
    public TextMeshProUGUI coinText;
    public GameObject gameManager;
    private GameplayData gameplayData;
    public GameObject audioManager;
    private AudioManager audioManagerScript;

    private CoinSystem coinSystem;
    private bool closeEnough = false;
    public bool gameWon = false;

    //MetriikkaData
    private int playerWinHealth;
    private float totalPlayTime;


    void Awake()
    {
        pouchEmpty.SetActive(true);
        pouchFilled.SetActive(false);
        pouchButton.gameObject.SetActive(false);
        pouchPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    private void Start()
    {
        coinSystem = gameManager.GetComponent<CoinSystem>();
        playerHealthScript = player.GetComponent<PlayerHealth>();
        audioManagerScript = audioManager.GetComponent<AudioManager>();
        gameplayData = gameManager.GetComponent<GameplayData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameWon)
        {
            playerWinHealth = playerHealthScript.GetCurrentHealth();
        }
        if((player.transform.position - this.transform.position).sqrMagnitude<1*1)
        {
            closeEnough = true;            
        }else
            closeEnough = false;
        
        if(closeEnough)
        {
            pouchButton.gameObject.SetActive(true);
        }else
            pouchButton.gameObject.SetActive(false);

        if(pouchPanel.activeSelf)
        {
            pouchButton.gameObject.SetActive(false);
        }
    }

    public void FillInCoins()
    {
        pauseButton.enabled = false;
        gameWon = true;
        playerWinHealth = playerHealthScript.GetCurrentHealth();
        totalPlayTime = Mathf.Round(Time.timeSinceLevelLoad);
        pouchPanel.SetActive(true);
        pouchEmpty.SetActive(false);
        pouchFilled.SetActive(true);
    }
    
    public void ClosePouchPanel()
    {
        audioManagerScript.Stop("Theme");
        audioManagerScript.Play("GameWin");
        pouchPanel.SetActive(false);
        winPanel.SetActive(true);
        coinText.text = coinSystem.getCoinsTotal().ToString();
    }

    public int GetPlayerWinHealth()
    {
        return playerWinHealth;
    }
    public int GetTotalPlayTime()
    {
        return (int)totalPlayTime;
    }
    public bool getGameWon()
    {
        return gameWon;
    }
}
