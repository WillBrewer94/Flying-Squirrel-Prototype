using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy1 : MonoBehaviour
{

    public GameObject[] waypoints;
    public int currWaypoint;
    public UnityEngine.AI.NavMeshAgent navy;
    public GameObject player;
    private Rigidbody rb;
    private CapsuleCollider collider;
    float distToGround = 0;
    public float jump = 2f;
    public bool active = true;

    public LayerMask groundLayers;

    //State Machine
    public enum AIState
    {
        Patrol,
        Target
    }

    public AIState aiState;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        aiState = AIState.Patrol;
        currWaypoint = -2;
        setNextWaypoint();
        navy = GetComponent<UnityEngine.AI.NavMeshAgent>();

        distToGround = GetComponent<CapsuleCollider>().bounds.extents.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            //State Machine
            switch (aiState)
            {
                case AIState.Patrol:
                    if (navy.remainingDistance < 1)
                    {
                        setNextWaypoint();
                    }
                    Vector3 target = player.GetComponent<Transform>().position;
                    Vector3 dist = (transform.position - target);
                    if (dist.magnitude < 11)
                    {
                        aiState = AIState.Target;
                    }
                    break;
                case AIState.Target:
                    chase();
                    break;
            }
            if (IsGrounded())
            {
                {
                }
            }
        }
    }

    private void setNextWaypoint()
    {
        if (currWaypoint < 0)
        {
            currWaypoint = 0;
        }
        else if (currWaypoint < waypoints.Length)
        {
            currWaypoint++;

        }
        else
      if (currWaypoint == waypoints.Length)
        {
            currWaypoint = 0;
        }
        if (currWaypoint >= 0 && currWaypoint < waypoints.Length)
        {
            navy.SetDestination(waypoints[currWaypoint].transform.position);
        }
    }

    private void chase()
    {
        Vector3 target = player.GetComponent<Transform>().position;
        Vector3 dist = (transform.position - target);
        navy.SetDestination(target);
        if ((transform.position - target).magnitude > 15)
        {
            aiState = AIState.Patrol;
        }
        if ((transform.position - target).magnitude < 1)
        {
            aiState = AIState.Patrol;
        }
    }

    public bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 1f);
    }

    
}
