using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OffsetScript : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent navMeshAgent;

    public GameObject waterBody;
    private WaterBodyTouchToMove water;

    public GameObject island1;
    private IslandScript islandScript;

    public bool offset = false;

    private void Start()
    {
        navMeshAgent = player.GetComponent<NavMeshAgent>();

        water = waterBody.GetComponent<WaterBodyTouchToMove>();

        islandScript = island1.GetComponent<IslandScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(islandScript.GetOnIsland() && water.GetInWater())
        {
            offset = true;
        }
        if(islandScript.GetOnIsland() && !water.GetInWater())
        {
            offset = true;
        }
        if(!islandScript.GetOnIsland() && water.GetInWater())
        {
            //offset = false;
        }
        if(!islandScript.GetOnIsland() && !water.GetInWater())
        {
            offset = true;
        }

        if(offset)
            navMeshAgent.baseOffset = 0f;
        
        if(!offset)
            navMeshAgent.baseOffset = -0.9f;
    }
}
