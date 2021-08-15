using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutScriptTouchToMove : MonoBehaviour
{
    public int damage = 20;
    public bool hasHit = false;

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.gameObject.CompareTag("Environment"))
        {
            hasHit = true;
        }
        if(other.collider.gameObject.CompareTag("Player"))
        {
            if(!hasHit)
            {
                PlayerHealthTouchToMove player = other.gameObject.GetComponent<PlayerHealthTouchToMove>();
                player.ReduceHealth(damage);
                FindObjectOfType<AudioManager>().Play("Coconut");
            }
            hasHit = true;
        }

        if(other.collider.gameObject.CompareTag("OceanTransparent"))
        {
            Destroy(gameObject);
        }
    }
}