using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRaft : MonoBehaviour
{

    public GameObject player;
    public GameObject raft;
    public Rigidbody raftRB;
    public Transform playerPos;
    public bool raftActive;
    public float transitionSpeed = 0.2f;
    
    public Image enterRaftButton;
    public Image exitRaftButton;
    public Image jumpButton;
    private Player playerInput;
    private CharacterController controller;
    PlayerController playerControlScript;
    private Transform cameraMain;

    public float speed = 1.0f;
    public float turnSpeed = 0.3f;
    private bool closeEnough = false;
    private bool enterRaftPressed = false;
    private bool exitRaftPressed = false;

    //Metriikkadata
    private float raftTimer;
    private int raftActiveCounter;

    Vector3 move;
    Vector2 movementInput;

    private void Awake()
    {
        playerInput = new Player();
        controller = player.GetComponent<CharacterController>();
        playerControlScript = player.GetComponent<PlayerController>();
        exitRaftButton.enabled = false;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        raftRB = GetComponent<Rigidbody>();
        cameraMain = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position - this.transform.position).sqrMagnitude<3*3)
        {
            closeEnough = true;
        }else
            closeEnough = false;

        if(closeEnough)
        {
            enterRaftButton.enabled = true;
        }else
            enterRaftButton.enabled = false;

        if(closeEnough && exitRaftPressed && raftActive)
        {
            ExitRaft();
        }else if(closeEnough && enterRaftPressed && !raftActive)
        {
            EnterRaft();
        }
        if(closeEnough && playerInput.PlayerMain.EnterRaft.triggered)
        {
            enterRaftPressed = true;
        }
        if(playerInput.PlayerMain.ExitRaft.triggered)
        {
            exitRaftPressed = true;
        }
        if(raftActive)
        {
            raftTimer += Time.deltaTime;
            //raftRB.useGravity = true;
            raftRB.isKinematic = false;
            movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
            move = new Vector3(movementInput.x, 0, movementInput.y);
            move = cameraMain.forward * move.z + cameraMain.right * move.x;
            move.y = 0f;
            player.transform.SetParent(this.transform);
            //move = playerInput.PlayerMain.Move.ReadValue<Vector2>();
            //movementInput = new Vector2(move.x, move.y);

            
        }else
        {
            movementInput = new Vector2(0, 0);
            //raftRB.useGravity = false;
            if(raftRB.velocity.magnitude < 0.1f)
            {
                raftRB.isKinematic = true;
            }
        }
        //Debug.Log((int)raftTimer);
    }

    void FixedUpdate()
    {
        //Vector3 raftMovement = new Vector3(move.x * 5f * Time.deltaTime, 0, move.y * 5f * Time.deltaTime);
        //raftRB.AddForce(movementInput * speed);
        raftRB.AddRelativeForce(Vector3.forward * movementInput.y * speed, ForceMode.Acceleration);
        raftRB.AddRelativeTorque(Vector3.up * movementInput.x * turnSpeed, ForceMode.VelocityChange);
    }

    private void EnterRaft()
    {
        playerControlScript.setRaftActive(true);
        controller.enabled = false;

        player.transform.position = Vector3.Lerp(player.transform.position, playerPos.position, transitionSpeed);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, playerPos.rotation, transitionSpeed);

        player.GetComponent<Animator>().SetBool("onRaft", true);

        if(Vector3.Distance(player.transform.position, playerPos.position) < 0.05)
        {
            raftActive = true;
            raftActiveCounter += 1;
        }
        exitRaftButton.enabled = true;
        jumpButton.enabled = false;
        playerControlScript.inWater = false;
        player.GetComponent<Animator>().SetFloat("Velocity", 0f);
    }
    private void ExitRaft()
    {
        controller.enabled = true;
        playerControlScript.setRaftActive(false);
        exitRaftPressed = false;
        enterRaftPressed = false;
        raftActive = false;
        player.GetComponent<Animator>().SetBool("onRaft", false);
        exitRaftButton.enabled = false;
        jumpButton.enabled = true;
        player.transform.parent = null;
    }

    public int getRaftTimer()
    {
        return (int)raftTimer;
    }
    public int getRaftActiveCounter()
    {
        return raftActiveCounter;
    }
}
