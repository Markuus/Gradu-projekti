using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    public GameObject player;
    public Button chestButton;
    public GameObject chestPanel;
    public GameObject gameManager;
    private RaftUpgrade raftUpgradeScript;
    public GameObject audioManager;
    private AudioManager audioManagerScript;

    private bool closeEnough = false;

    //Metriikkadata
    private bool chestOpened = false;

    private void Awake()
    {
        raftUpgradeScript = gameManager.GetComponent<RaftUpgrade>();
        audioManagerScript = audioManager.GetComponent<AudioManager>();
        chestButton.gameObject.SetActive(false);
        chestPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if((player.transform.position - this.transform.position).sqrMagnitude<2*2)
        {
            closeEnough = true;            
        }else
            closeEnough = false;
        
        if(closeEnough)
        {
            chestButton.gameObject.SetActive(true);
        }else
            chestButton.gameObject.SetActive(false);

        if(chestPanel.activeSelf)
        {
            chestButton.gameObject.SetActive(false);
        }
    }

    public void openChest()
    {
        audioManagerScript.Play("RaftUpgrade");        
        chestOpened = true;
        chestPanel.SetActive(true);
        raftUpgradeScript.changeRaft();

    }

    public void closeChest()
    {
        chestPanel.SetActive(false);

        Destroy(gameObject);
    }

    public bool GetChestOpened()
    {
        return chestOpened;
    }

}
