using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBody : MonoBehaviour
{

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<PlayerController>() == player)
        {
            if(!player.inWater)
                player.inWater = true;
            
            if(player.waterSurface != transform.position.y)
                player.waterSurface = transform.position.y;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<PlayerController>() == player)
        {
            if(player.inWater)
                player.inWater = false;
        }
    }
}
