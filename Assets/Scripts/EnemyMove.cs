using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public float distanceToPlayer;
    public Transform player;

    private int currentWaypointIndex;
    private bool playerInRange;

    void Start()
    {
        currentWaypointIndex = 0;
        playerInRange = false;
    }

    void Update()
    {
        if (!playerInRange)
        {
            Patrol();
        }
        else
        {
            Chase();
        }
    }

    void Patrol()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, step);

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.01f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        if (Vector3.Distance(transform.position, player.position) < distanceToPlayer)
        {
            playerInRange = true;
        }
    }

    void Chase()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);

        if (Vector3.Distance(transform.position, player.position) > distanceToPlayer)
        {
            playerInRange = false;
        }
    }
}

