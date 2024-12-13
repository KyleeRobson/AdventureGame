using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleNavMeshAgent : MonoBehaviour
{
    public Transform[] waypoints; // Assign the TargetPoint in the Inspector
    private int currentWaypointIndex;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        if (waypoints.Length > 0 )
        {
            agent.SetDestination(waypoints[0].position);
        }
    }

    private void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
           currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}
