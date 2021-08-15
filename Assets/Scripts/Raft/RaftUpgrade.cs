using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftUpgrade : MonoBehaviour
{

    public GameObject raft;
    public GameObject raftSails;

    private GameObject activeRaft;
    private GameObject unactiveRaft;
    //Used for changing the active raft
    private GameObject xRaft;

    private Transform raftPos;

    private bool chestOpened = false;

    void Start()
    {
        raft.SetActive(true);
        raftSails.SetActive(false);

        activeRaft = raft;
        unactiveRaft = raftSails;
    }

    // Update is called once per frame
    void Update()
    {
        if(chestOpened)
        {
            activeRaft = raftSails;
            unactiveRaft = raft;
        }

        raftPosition();

        
    }

    public void chestOpen()
    {
        chestOpened = true;
    }

    public void raftPosition()
    {
        raftPos = activeRaft.transform;
    }

    public void changeRaft()
    {
        xRaft = activeRaft;
        activeRaft = raftSails;
        unactiveRaft = xRaft;

        activeRaft.transform.position = raftPos.position;
        activeRaft.transform.rotation = raftPos.rotation;
        //activeRaft.SetActive(true);
        //unactiveRaft.SetActive(false);
        //Debug.Log(raft.activeSelf);
        //Debug.Log(raftSails.activeSelf);
        raft.SetActive(false);
        raftSails.SetActive(true);

    }
}
