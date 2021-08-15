using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GameplayData : MonoBehaviour
{

    //GAMEOBJECTS
    public GameObject raft;
    private MoveRaft moveRaftScript;
    public GameObject raftSails;
    private MoveRaft moveRaftSailsScript;
    public GameObject player;
    private PlayerController playerControllerScript;
    private PlayerHealth playerHealthScript;
    public GameObject coinPouch;
    private CoinPouchScript coinPouchScript;
    public GameObject chest;
    private ChestScript chestScript;
    private CoinSystem coinSystem;
    public GameObject pausePanel;
    private PauseMenu pauseMenuScript;
    public GameObject networkErrorPanel;
    public GameObject gridLayout;
    public GameObject endGameButton;
    public GameObject menuButton;

    //ID
    public string id;


    //AJASTIMET
    public float playTime;
    public float raftTimer;
    public float playerInWaterTimer;

    //LAUTTA
    public int raftActiveCounter;
    public bool raftUpgraded;

    //PELAAJA
    public int jumpCounter;
    public int currentHealth;
    public int coconutHits;
    public int coconutsThrown;
    public int pineapplesCollected;
    public int deathCounter;
    public int totalCoins;
    public int totalDistance;
    private float distanceTravelled;
    private Vector3 lastPosition;

    //MUUT
    public int timesPaused;
    public bool gameWon;

    //GOOGLE FORMS MUUTTUJAT STRING-MUODOSSA
    private string Game = "1";
    private string PlayTime;
    private string RaftTimer;
    private string PlayerInWaterTimer;
    private string RaftActiveCounter;
    private string RaftUpgraded;
    private string JumpCounter;
    private string CurrentHealth;
    private string CoconutHits;
    private string CoconutsThrown;
    private string PineapplesCollected;
    private string DeathCounter;
    private string TotalCoins;
    private string TotalDistance;
    private string TimesPaused;
    private string GameWon;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdIMaXDo6FeRc2ZfWVFERQZILdXEATfFmdeJvsOZ1NsW1mVNg/formResponse";


    // Start is called before the first frame update
    void Start()
    {
        id = FindObjectOfType<IDSaver>().getId();
        moveRaftScript = raft.GetComponent<MoveRaft>();
        playerControllerScript = player.GetComponent<PlayerController>();
        playerHealthScript = player.GetComponent<PlayerHealth>();
        coinPouchScript = coinPouch.GetComponent<CoinPouchScript>();
        chestScript = chest.GetComponent<ChestScript>();
        coinSystem = this.GetComponent<CoinSystem>();
        pauseMenuScript = pausePanel.GetComponent<PauseMenu>();
        moveRaftSailsScript = raftSails.GetComponent<MoveRaft>();

        lastPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playTime = Mathf.Round(Time.timeSinceLevelLoad);

        //LAUTTA
        raftTimer = moveRaftScript.getRaftTimer() + moveRaftSailsScript.getRaftTimer();
        raftActiveCounter = moveRaftScript.getRaftActiveCounter() + moveRaftSailsScript.getRaftActiveCounter();
        raftUpgraded = chestScript.GetChestOpened();

        //PELAAJA
        jumpCounter = playerControllerScript.GetJumpCounter();
        playerInWaterTimer = playerControllerScript.GetInWaterTimer();
        currentHealth = coinPouchScript.GetPlayerWinHealth();
        coconutHits = playerHealthScript.GetCoconutHits();
        pineapplesCollected = playerHealthScript.GetPineapplesCollected();
        deathCounter = playerHealthScript.GetDeathCounter();
        totalCoins = coinSystem.getCoinsTotal();

        //KOKONAISMATKA
        float distance = Vector3.Distance(lastPosition, player.transform.position);
        distanceTravelled += distance;
        lastPosition = player.transform.position;
        totalDistance = Mathf.RoundToInt(distanceTravelled);


        //Muut
        timesPaused = pauseMenuScript.GetPauseCounter();
        if(timesPaused == -1)
        {
            timesPaused = 0;
        }
        gameWon = coinPouchScript.getGameWon();
        
    }


    public void AddCoconutsThrown()
    {
        coconutsThrown += 1;
    }

    IEnumerator Post(string game, string idnumber, string playtime, string rafttimer, string playerinwatertimer, string raftactivecounter, string raftupgraded, string jumpcounter, string currenthealth, string coconuthits, string coconutsthrown, string pineapplescollected, string deathcounter, string totalcoins, string totaldistance, string timespaused, string gamewon)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.801054075", game);
        form.AddField("entry.1762898785", idnumber);
        form.AddField("entry.1951144906", playtime);
        form.AddField("entry.1498578089", rafttimer);
        form.AddField("entry.1436451851", playerinwatertimer);
        form.AddField("entry.66021496", raftactivecounter);
        form.AddField("entry.1613330815", raftupgraded);
        form.AddField("entry.219782182", jumpcounter);
        form.AddField("entry.1582425972", currenthealth);
        form.AddField("entry.1425349000", coconuthits);
        form.AddField("entry.507118935", coconutsthrown);
        form.AddField("entry.637713165", pineapplescollected);
        form.AddField("entry.649278061", deathcounter);
        form.AddField("entry.1770148837", totalcoins);
        form.AddField("entry.1726142814", totaldistance);
        form.AddField("entry.506930348", timespaused);
        form.AddField("entry.1698511112", gamewon);

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if(www.isNetworkError)
        {
            Debug.Log(www.error);
            networkErrorPanel.SetActive(true);
            TMP_Text text1 =  gridLayout.transform.GetChild(0).GetComponent<TMP_Text>();
            gridLayout.transform.GetChild(0).GetComponent<TMP_Text>().text += " " + game;
            gridLayout.transform.GetChild(1).GetComponent<TMP_Text>().text += " " + idnumber;
            gridLayout.transform.GetChild(2).GetComponent<TMP_Text>().text += " " + playtime;
            gridLayout.transform.GetChild(3).GetComponent<TMP_Text>().text += " " + rafttimer;
            gridLayout.transform.GetChild(4).GetComponent<TMP_Text>().text += " " + playerinwatertimer;
            gridLayout.transform.GetChild(5).GetComponent<TMP_Text>().text += " " + raftactivecounter;
            gridLayout.transform.GetChild(6).GetComponent<TMP_Text>().text += " " + raftupgraded;
            gridLayout.transform.GetChild(7).GetComponent<TMP_Text>().text += " " + jumpcounter;
            gridLayout.transform.GetChild(8).GetComponent<TMP_Text>().text += " " + currenthealth;
            gridLayout.transform.GetChild(9).GetComponent<TMP_Text>().text += " " + coconuthits;
            gridLayout.transform.GetChild(10).GetComponent<TMP_Text>().text += " " + coconutsthrown;
            gridLayout.transform.GetChild(11).GetComponent<TMP_Text>().text += " " + pineapplescollected;
            gridLayout.transform.GetChild(12).GetComponent<TMP_Text>().text += " " + deathcounter;
            gridLayout.transform.GetChild(13).GetComponent<TMP_Text>().text += " " + totalcoins;
            gridLayout.transform.GetChild(14).GetComponent<TMP_Text>().text += " " + totaldistance;
            gridLayout.transform.GetChild(15).GetComponent<TMP_Text>().text += " " + timespaused;
            gridLayout.transform.GetChild(16).GetComponent<TMP_Text>().text += " " + gamewon;
        }else
        {
            Debug.Log("Data lähetetty Google Formsiin!");
            endGameButton.SetActive(false);
            menuButton.SetActive(true);
        }
    }

    public void SendDataToGoogleForms()
    {
        PlayTime = playTime.ToString();
        RaftTimer = raftTimer.ToString();
        PlayerInWaterTimer = playerInWaterTimer.ToString();
        RaftActiveCounter = raftActiveCounter.ToString();
        RaftUpgraded = raftUpgraded.ToString();
        JumpCounter = jumpCounter.ToString();
        CurrentHealth = currentHealth.ToString();
        CoconutHits = coconutHits.ToString();
        CoconutsThrown = coconutsThrown.ToString();
        PineapplesCollected = pineapplesCollected.ToString();
        DeathCounter = deathCounter.ToString();
        TotalCoins = totalCoins.ToString();
        TotalDistance = totalDistance.ToString();
        TimesPaused = timesPaused.ToString();
        GameWon = gameWon.ToString();
        StartCoroutine(Post(Game, id, PlayTime, RaftTimer, PlayerInWaterTimer, RaftActiveCounter, RaftUpgraded, JumpCounter, CurrentHealth, CoconutHits, CoconutsThrown, PineapplesCollected, DeathCounter, TotalCoins, TotalDistance, TimesPaused, GameWon));
    }

}
