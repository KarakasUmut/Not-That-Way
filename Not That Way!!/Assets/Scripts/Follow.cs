using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (player)
    public float followDistance; // Takip mesafesi

    private NavMeshAgent agent; // NavMeshAgent bileþeni

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Hedefin pozisyonunu al
        Vector3 targetPosition = target.position - (target.forward * followDistance);

        // Takip mesafesini korumak için hedef pozisyonunu düzelt
        Vector3 currentPosition = transform.position;
        Vector3 directionToTarget = targetPosition - currentPosition;
        float distanceToTarget = directionToTarget.magnitude;
        if (distanceToTarget < followDistance)
        {
            targetPosition = currentPosition + directionToTarget.normalized * followDistance;
        }

        // NavMeshAgent'e hedef pozisyonunu ver
        agent.SetDestination(targetPosition);
    }
}
