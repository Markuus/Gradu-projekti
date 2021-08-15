using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaterBodyTouchToMove : MonoBehaviour
{
    public GameObject player;

    NavMeshAgent navMeshAgent;

    public bool isEffective = true;

    private bool inWater = false;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = player.GetComponent<NavMeshAgent>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inWater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inWater = false;
        }
    }

    public bool GetInWater()
    {
        return inWater;
    }


    public void setEffective(bool x)
    {
        isEffective = x;
    }
}
