using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float walkSpeed = 2;
    public float runSpeed = 6;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    bool runActivated = false;
    bool runX = false;
    bool runY = false;


    private Player playerInput;
    private Transform cameraMain;
    Animator animator;

    void Awake()
    {
        playerInput = new Player();
        animator = GetComponent<Animator>();    
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
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input =  playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector2 inputDir = input.normalized;
        Vector3 cameraMove = (cameraMain.forward * input.y + cameraMain.right * input.x);

        if (inputDir != Vector2.zero) {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        //Juoksun tarkistus
        if (input.x > 0.5f || input.x < -0.5f) 
        {
            runX = true;
        }
        else
            runX = false;
        if (input.y > 0.5f || input.y < -0.5f)
        {
            runY = true;
        }
        else
            runY = false;
        if (runX == true || runY == true)
        {
            runActivated = true;
        }
        else
            runActivated = false;


        bool running = runActivated;
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = ((running) ? 1 : 0.5f) * inputDir.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
    }
}
