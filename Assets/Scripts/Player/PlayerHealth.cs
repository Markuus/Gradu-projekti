using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;
    public GameObject playerDeadPanel;
    public GameObject audioManager;
    private AudioManager audioManagerScript;
    public GameObject spawnPoint1;
    private float distance1;
    public GameObject spawnPoint2;
    private float distance2;
    public GameObject spawnPoint3;
    private float distance3;
    private PlayerController controller;
    private AnimationStateController anim;

    //Metriikkadata
    private int coconutHits;
    private int pineapplesCollected;
    private int deathCounter;


    private void Start()
    {
        controller = GetComponent<PlayerController>();
        anim = GetComponent<AnimationStateController>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audioManagerScript = audioManager.GetComponent<AudioManager>();
    }

    public void ReduceHealth(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        coconutHits += 1;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth > 100)
        {
            currentHealth = 100;
        }
        healthBar.SetHealth(currentHealth);
        pineapplesCollected += 1;
    }

    public void Die()
    {
        audioManagerScript.Stop("Theme");
        audioManagerScript.Play("PlayerDeath");
        controller.SetCanMove(false);
        anim.SetCanMove(false);
        playerDeadPanel.SetActive(true);
        deathCounter += 1;
    }

    public void ResPawn()
    {
        audioManagerScript.Stop("PlayerDeath");
        audioManagerScript.Play("Theme");
        currentHealth = 100;
        healthBar.SetHealth(currentHealth);
        controller.SetCanMove(true);
        anim.SetCanMove(true);
        playerDeadPanel.SetActive(false);
        distance1 = Vector3.Distance(this.transform.position, spawnPoint1.transform.position);
        distance2 = Vector3.Distance(this.transform.position, spawnPoint2.transform.position);
        distance3 = Vector3.Distance(this.transform.position, spawnPoint3.transform.position);
        if(distance1 < distance2 && distance1 < distance3)
        {
            this.transform.position = spawnPoint1.transform.position;
            this.transform.rotation = spawnPoint1.transform.rotation;
        }
        if(distance2 < distance1 && distance2 < distance3)
        {
            this.transform.position = spawnPoint2.transform.position;
            this.transform.rotation = spawnPoint2.transform.rotation;
        }
        if(distance3 < distance2 && distance3 < distance1)
        {
            this.transform.position = spawnPoint3.transform.position;
            this.transform.rotation = spawnPoint3.transform.rotation;
        }
        
        
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public int GetCoconutHits()
    {
        return coconutHits;
    }
    public int GetPineapplesCollected()
    {
        return pineapplesCollected;
    }
    public int GetDeathCounter()
    {
        return deathCounter;
    }

}
