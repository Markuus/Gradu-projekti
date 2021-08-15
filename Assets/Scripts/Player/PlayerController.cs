using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 15f;

    public float distToGround = 0.7f;
    public GameObject audioManager;
    private AudioManager audioManagerScript;


    private Transform cameraMain;

    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public bool raftActive = false;

    private Player playerInput;

    //Swimming
    public float waterSurface;
    public bool inWater;
    public float upForce = 1f;
    private bool canMove = true;

    //Metriikkadata
    private int jumpCounter;
    private float inWaterTimer;


    private void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();
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
        cameraMain = Camera.main.transform;
        audioManagerScript = audioManager.GetComponent<AudioManager>();
    }

    void Update()
    {
        if(!raftActive) 
        {
            if(canMove)
            {
                isGrounded();
                //groundedPlayer = controller.isGrounded;
                if (groundedPlayer && playerVelocity.y < 0)
                {
                    playerVelocity.y = 0f;
                }
                
                Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
                Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
                move = cameraMain.forward * move.z + cameraMain.right * move.x;
                move.y = 0f;

                controller.Move(move * Time.deltaTime * playerSpeed);
                
                // Hyppy
                if (playerInput.PlayerMain.Jump.triggered && groundedPlayer)
                {
                    jumpCounter += 1;
                    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                    audioManagerScript.Play("Jump");
                }
                playerVelocity.y += gravityValue * Time.deltaTime;
                controller.Move(playerVelocity * Time.deltaTime);

                    
                if(movementInput != Vector2.zero)
                {
                    float targetAngle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg + cameraMain.eulerAngles.y;
                    Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
                }
            }
        }
        
        
        if(inWater)
        {
            inWaterTimer += Time.deltaTime;
        }
        
    }

    void isGrounded()
    {
        if(Physics.Raycast(transform.position, Vector3.down, distToGround))
        {
            groundedPlayer = true;
        }else
        {
            groundedPlayer = false;
        }
    }

    public void setRaftActive(bool active)
    {
        raftActive = active;
    }

    void isInWater()
    {
        if(waterSurface > transform.position.y)
        {
            //playerVelocity.y += -gravityValue * Time.deltaTime;
            //controller.Move(playerVelocity * Time.deltaTime);
        }
    }

    public void SetCanMove(bool can)
    {
        canMove = can;
    }

    public int GetJumpCounter()
    {
        return jumpCounter;
    }
    public int GetInWaterTimer()
    {
        return (int)inWaterTimer;
    }

}
