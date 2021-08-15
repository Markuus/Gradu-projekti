using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MoveRaftWithTouch : MonoBehaviour
{

    public GameObject player;
    public NavMeshAgent navMeshAgentPlayer;
    public CinemachineVirtualCamera cinemachine;
    private CinemachinePOV cinemachinePOV;
    public GameObject destinationMarker;
    private bool tapped;
    private bool hold;
    private float timer;

    private NavMeshAgent navMeshAgentRaft;
    public Rigidbody raftRB;
    public Transform playerPos;
    public bool raftActive;
    public float transitionSpeed = 0.2f;
    
    public Image enterRaftButton;
    public Image exitRaftButton;
    private Player playerInput;
    private Transform cameraMain;

    private bool closeEnough = false;
    private bool enterRaftPressed = false;
    private bool exitRaftPressed = false;

    public GameObject island1;
    private IslandScript islandScript1;
    public GameObject island2;
    private IslandScript islandScript2;
    public GameObject island3;
    private IslandScript islandScript3;

    //Metriikkadata
    private float raftTimer;
    private int raftActiveCounter;
    private int destinationMarkerCounter;


    private void Awake()
    {
        playerInput = new Player();
        exitRaftButton.enabled = false;
        navMeshAgentPlayer = player.GetComponent<NavMeshAgent>();
        navMeshAgentRaft = this.GetComponent<NavMeshAgent>();

        cinemachinePOV = cinemachine.GetCinemachineComponent<CinemachinePOV>();

        playerInput.PlayerMain2.TouchPress.performed += x => tapped = true;
        hold = false;
        playerInput.PlayerMain2.TouchPress2.started += x => {hold = true;};
        playerInput.PlayerMain2.TouchPress2.performed += x => {hold = true;};
        playerInput.PlayerMain2.TouchPress2.canceled += x => {hold = false;};

        islandScript1 = island1.GetComponent<IslandScript>();
        islandScript2 = island2.GetComponent<IslandScript>();
        islandScript3 = island3.GetComponent<IslandScript>();

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
            player.transform.SetParent(this.transform);

            if(hold)
            {
                timer += Time.deltaTime;
            }else if(!hold)
            {
                timer = 0;
            }
            if(tapped && !EventSystem.current.currentSelectedGameObject && Time.timeScale != 0f)
            {
                Ray ray = Camera.main.ScreenPointToRay(playerInput.PlayerMain2.TouchPosition.ReadValue<Vector2>());
                RaycastHit hit;
                if(playerInput.PlayerMain2.TouchPress.triggered)
                {
                    if(Physics.Raycast(ray, out hit, 25))
                    {
                        navMeshAgentRaft.destination = hit.point;
                        Vector3 markerPosition = hit.point;
                        destinationMarker.SetActive(true);
                        destinationMarker.transform.position = markerPosition;
                        destinationMarkerCounter += 1;
                    }
                }
            }
            if((destinationMarker.transform.position - this.transform.position).sqrMagnitude<1)
            {
                destinationMarker.SetActive(false);
            }

            if(timer > 0.2f)
            {
                //Vector2 delta = playerInput.PlayerMain2.LookAround.ReadValue<Vector2>().normalized;
                //cinemachinePOV.m_VerticalAxis.Value += -delta.y * 30 * Time.deltaTime;
                //cinemachinePOV.m_HorizontalAxis.Value += delta.x * 80 * Time.deltaTime;
            }

            tapped = false;
    
        }
    }

    private void EnterRaft()
    {
        player.GetComponent<TouchToMove>().setOnRaft(true);
        navMeshAgentPlayer.baseOffset = 0f;
        navMeshAgentPlayer.enabled = false;
        navMeshAgentPlayer.transform.rotation = Quaternion.Slerp(navMeshAgentPlayer.transform.rotation, playerPos.rotation, transitionSpeed);
        navMeshAgentPlayer.Warp(playerPos.position);

        //Saarien navMeshObstaclen deactivointi
        islandScript1.ActivateNavMeshObj(true);
        islandScript2.ActivateNavMeshObj(true);
        islandScript3.ActivateNavMeshObj(true);

        player.GetComponent<Animator>().SetBool("onRaft", true);
        if(Vector3.Distance(player.transform.position, playerPos.position) < 0.07)
        {
            raftActive = true;
            raftActiveCounter += 1;
            navMeshAgentRaft.enabled = true;
            navMeshAgentRaft.isStopped = false;
        }
        exitRaftButton.enabled = true;
    }
    private void ExitRaft()
    {
        player.GetComponent<TouchToMove>().setOnRaft(false);
        navMeshAgentPlayer.baseOffset = 0f;
        navMeshAgentPlayer.enabled = true;
        navMeshAgentRaft.enabled = false;

        //Saarien navMeshObstaclen activointi
        islandScript1.ActivateNavMeshObj(false);
        islandScript2.ActivateNavMeshObj(false);
        islandScript3.ActivateNavMeshObj(false);

        exitRaftPressed = false;
        enterRaftPressed = false;
        raftActive = false;
        player.GetComponent<Animator>().SetBool("onRaft", false);
        exitRaftButton.enabled = false;
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
    public int GetDestinationMarkerCounter()
    {
        return destinationMarkerCounter;
    }

}
