using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScript : MonoBehaviour
{
    private CoconutScript coconutScript;
    public GameObject coconut;
    public GameObject player;
    public GameObject gameManager;
    public GameObject coinPouchSystem;
    private CoinPouchScript coinPouchScript;
    private GameplayData gameplayData;
    private Animator monkeyAnimator;
    private int throwActiveHash;
    private int playerHitHash;
    //public float throwingPower = 2f;
    private float distance;
    private bool canThrow = true;
    [SerializeField]
    public float delay = 3.0f;
    private float timeStamp = 0f;

    private int playerLastHealth;
    private int playerHealth;


    public GameObject coconutParent;


    private void Awake()
    {
        coconutScript = coconut.GetComponent<CoconutScript>();
        monkeyAnimator = GetComponent<Animator>();
        coinPouchScript = coinPouchSystem.GetComponent<CoinPouchScript>();
    }

    private void Start()
    {
        throwActiveHash = Animator.StringToHash("ThrowActive");
        playerHitHash = Animator.StringToHash("PlayerHit");
        gameplayData = gameManager.GetComponent<GameplayData>();
        playerLastHealth = 100;
    }

    private void Update()
    {
        playerHealth = player.GetComponent<PlayerHealth>().GetCurrentHealth();
        DistanceToPlayer();
        if(distance < 10 && canThrow && !coinPouchScript.gameWon && playerHealth > 0)
        {
            monkeyAnimator.SetTrigger("Throw");
            canThrow = false;
            timeStamp = Time.time + delay;
        }
        if(Time.time > timeStamp)
        {
            canThrow = true;
        }else
            canThrow = false;

        //Debug.Log("playerLastHealth: " + playerLastHealth);
        //Debug.Log("currentHealth: " + player.GetComponent<PlayerHealth>().GetCurrentHealth());

        if(playerHealth < playerLastHealth)
        {
            monkeyAnimator.SetTrigger("PlayerHit");
            //Debug.Log("Osuma");
        }
        playerLastHealth = playerHealth;

    }

    public void DistanceToPlayer()
    {
        distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if(distance < 10)
        {
            Vector3 lookAtPosition = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            this.transform.LookAt(lookAtPosition);
        }
    }

    public void ThrowCoconut()
    {
        GameObject temporaryCoconut;
        temporaryCoconut = Instantiate(coconut, coconutParent.transform.position, coconutParent.transform.rotation) as GameObject;
        temporaryCoconut.transform.parent = coconutParent.transform;

        Rigidbody temporaryRigidbody;
        temporaryRigidbody = temporaryCoconut.GetComponent<Rigidbody>();
        temporaryRigidbody.useGravity = false;
        ReleaseCoconut(temporaryCoconut, temporaryRigidbody);
    }

    public void ReleaseCoconut(GameObject coco, Rigidbody rb)
    {
        coco.transform.parent = null;

        rb.useGravity = true;
        coco.transform.rotation = coconutParent.transform.rotation;
        rb.AddForce(transform.forward*100*(distance/1.2f));
        gameplayData.AddCoconutsThrown();
    }
}
