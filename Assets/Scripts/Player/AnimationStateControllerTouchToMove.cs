using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationStateControllerTouchToMove : MonoBehaviour
{

    Animator animator;
    private Player playerInput;
    private NavMeshAgent navMeshAgent;
    int VelocityHash;
    float velocity = 0.0f;
    private bool canMove = true;
    private bool inWater = false;

    private void Awake() 
    {
        playerInput = new Player();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
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
        animator.SetBool("inWater", inWater);

        velocity = navMeshAgent.velocity.magnitude;
        animator.SetFloat(VelocityHash, velocity);
        
    }

    public void SetCanMove(bool can)
    {
        canMove = can;
    }

}
