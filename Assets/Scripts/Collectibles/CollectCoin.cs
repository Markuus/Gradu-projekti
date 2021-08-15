using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public GameObject audioManager;
    private AudioManager audioManagerScript;

    public int rotationSpeed = 20;
    public float speed = 2;
    
    public float hoverMax = 1f;
    public float hoverMin = 0.4f;
    private float hoverMinReal;
    private bool up = true;

    private void Start()
    {
        hoverMinReal = 1-hoverMin;
        audioManagerScript = audioManager.GetComponent<AudioManager>();
    }
    private void Update()
    {
        transform.Rotate(0, rotationSpeed*Time.deltaTime, 0);

        RaycastHit hit;
        Ray downRay = new Ray(transform.position, -Vector3.up);

        if(Physics.Raycast(downRay, out hit))
        {
            float hoverPoint = hoverMax - hit.distance;
            if(hoverPoint < 0.1)
            {
                up = false;
            }else if(hoverPoint > hoverMinReal)
            {
                up = true;
            }
            if(hoverPoint >= 0 && up)
            {
                transform.Translate(Vector3.up * 0.1f * speed * Time.deltaTime);
            }else if(hoverPoint < hoverMinReal)
            {
            transform.Translate(Vector3.down * 0.1f * speed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            CoinSystem.coinsTotal += 1;
            audioManagerScript.Play("Coin");
            Destroy(gameObject);
        }
    }
}