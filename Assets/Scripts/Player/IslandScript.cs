using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IslandScript : MonoBehaviour
{

    public GameObject player;
    private NavMeshAgent navMeshAgent;

    public GameObject waterBody;
    private WaterBodyTouchToMove water;

    private NavMeshObstacle navMeshObj;
    public GameObject navMeshAddon;
    private bool onIsland = false;

    private void Start()
    {
        navMeshAgent = player.GetComponent<NavMeshAgent>();
        navMeshObj = this.GetComponent<NavMeshObstacle>();
        water = waterBody.GetComponent<WaterBodyTouchToMove>();

        ActivateNavMeshObj(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            onIsland = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            onIsland = false;
        }
    }

    public void ActivateNavMeshObj(bool x)
    {
        navMeshObj.enabled = x;
        if(this.name == "Island3")
        {
            navMeshAddon.GetComponent<NavMeshObstacle>().enabled = x;
        }

    }

    public bool GetOnIsland()
    {
        return onIsland;
    }
}
