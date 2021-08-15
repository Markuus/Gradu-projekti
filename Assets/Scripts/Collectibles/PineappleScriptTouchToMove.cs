using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleScriptTouchToMove : MonoBehaviour
{
    public GameObject audioManager;
    private AudioManager audioManagerScript;

    public int health = 25;

    private void Start()
    {
        audioManagerScript = audioManager.GetComponent<AudioManager>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            audioManagerScript.Play("Pineapple");
            PlayerHealthTouchToMove player = other.gameObject.GetComponent<PlayerHealthTouchToMove>();
            player.AddHealth(health);
            Destroy(gameObject);
        }
    }
}
