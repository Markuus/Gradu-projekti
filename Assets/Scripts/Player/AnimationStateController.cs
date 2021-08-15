using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;
    private Player playerInput;
    private CharacterController controller;
    private PlayerController playerControllerScript;
    int VelocityHash;
    float velocity = 0.0f;
    public float speedSmoothTime = 0.1f;
    public float acceleration = 0.2f;
    public float deceleration = 5f;
    private bool canMove = true;
    private bool inWater = false;

    private void Awake() 
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();
        playerControllerScript = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();   
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
    }


    // Update is called once per frame
    void Update()
    {
        bool jumpTriggered = playerInput.PlayerMain.Jump.triggered;
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector2 inputDir = movementInput.normalized;
        bool walkActivated = false;
        bool walkX = false;
        bool walkY = false;
        bool runActivated = false;
        bool runX = false;
        bool runY = false;

        inWater = playerControllerScript.inWater;
        if(inWater && gameObject.transform.position.y <= -0.7)
        {
            animator.SetBool("inWater", inWater);
        }else{
            animator.SetBool("inWater", false);
        }


        //Kävelyn tarkistus
        if ((movementInput.x > 0f && movementInput.x <= 0.5f) || (movementInput.x < 0f && movementInput.x >= -0.5f)) 
        {
            walkX = true;
        }
        if ((movementInput.y > 0f && movementInput.y <= 0.5f) || (movementInput.y < 0f && movementInput.y >= -0.5f)) 
        {
            walkY = true;
        }
        if (walkX == true && walkY == true) 
        {
            walkActivated = true;
        }

        //Juoksun tarkistus
        if (movementInput.x > 0.5f || movementInput.x < -0.5f) 
        {
            runX = true;
        }
        if (movementInput.y > 0.5f || movementInput.y < -0.5f)
        {
            runY = true;
        }
        if (runX == true || runY == true)
        {
            runActivated = true;
        }
        else
            runActivated = false;

        bool running = runActivated;

        if (walkActivated && velocity < 0.3f)
        {
            velocity += Time.deltaTime * acceleration;
        }
        if (runActivated && velocity < 1.0f)
        {
            velocity += Time.deltaTime * (acceleration * 2f);
        }
        if ((!walkActivated && !runActivated) && velocity > 0.0f)
        {
            velocity = 0.0f;
        }
        if(!walkActivated && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        if (jumpTriggered && !playerControllerScript.inWater) 
        {
            animator.SetBool("jumpTriggered", true);
        }
        else
            animator.SetBool("jumpTriggered", false);

        if(canMove)
        {
            //animator.SetFloat(VelocityHash, velocity);
            if(!playerControllerScript.raftActive)
            {
                float animationSpeedPercent = ((running) ? 1 : 0.5f) * inputDir.magnitude;
                animator.SetFloat("Velocity", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
            }
        }
    }

    public void SetCanMove(bool can)
    {
        canMove = can;
    }

}
