using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.EventSystems;

public class TouchToMove : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public CinemachineVirtualCamera cinemachine;
    private CinemachinePOV cinemachinePOV;
    private Player player;

    public GameObject destinationMarker;
    private bool tapped;
    private bool hold;

    public bool onRaft = false;
    private float timer;

    //Metriikkadata
    private int destinationMarkerCounter;

    private void Awake()
    {
        player = new Player();
        cinemachinePOV = cinemachine.GetCinemachineComponent<CinemachinePOV>();

        player.PlayerMain2.TouchPress.performed += x => tapped = true;
        hold = false;
        player.PlayerMain2.TouchPress2.started += x => {hold = true;};
        player.PlayerMain2.TouchPress2.performed += x => {hold = true;};
        player.PlayerMain2.TouchPress2.canceled += x => {hold = false;};

    }

    private void OnEnable()
    {
        player.Enable();
    }
    private void OnDisable()
    {
        player.Disable();
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(hold)
        {
            timer += Time.deltaTime;
        }else if(!hold)
        {
            timer = 0;
        }
        //Debug.Log(Touchscreen.current.primaryTouch.);
        if(tapped && !onRaft && !EventSystem.current.currentSelectedGameObject && Time.timeScale != 0f)
        {
            Ray ray = Camera.main.ScreenPointToRay(player.PlayerMain2.TouchPosition.ReadValue<Vector2>());
            RaycastHit hit;
            if(player.PlayerMain2.TouchPress.triggered)
            {
                if(Physics.Raycast(ray, out hit, 25))
                {
                    navMeshAgent.destination = hit.point;
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
            Vector2 delta = player.PlayerMain2.LookAround.ReadValue<Vector2>().normalized;
            cinemachinePOV.m_VerticalAxis.Value += -delta.y * 50 * Time.deltaTime;
            cinemachinePOV.m_HorizontalAxis.Value += delta.x * 100 * Time.deltaTime;
        }

        tapped = false;
        
    }

    public void setOnRaft(bool x)
    {
        onRaft = x;
    }

    public int GetDestinationMarkerCounter()
    {
        return destinationMarkerCounter;
    }
    

    /*
    private void OnCollisionStay(Collision other)
    {
        if(other.collider.gameObject.name == "Raft")
        {
            onRaft = true;
        }
        Debug.Log(other.gameObject.name);

    }
    */


}
