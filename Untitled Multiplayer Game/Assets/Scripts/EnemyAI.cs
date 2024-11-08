using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 20f; // Range to detect the player
    public List<Transform> patrolWaypoints; // List of patrol waypoints
    private NavMeshAgent agent; //the nav mesh agent
    private int currentWaypointIndex = 0;
    public float interestDuration = 5f; //float for intrest duration 
    private float timeSinceLastSighting = 0f; //float for time since last sighting
    public float rotationSpeed = 5f; //how fast the enemy rotates 

    public Transform detectionObjects;
    private Vector3 lastknownPlayerPosition;
    public float range = 200f; //how far the raycast is shot
    public PlayerHealth playerHealth; //the player health script

    public enum EnemyState
    {
        Patrol,
        Chase,
    }

    private EnemyState currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //gets the navmesh component
        currentState = EnemyState.Patrol; //sets the state at the beginning of the game to EnemyState.Patrol
        SetNextWaypoint(); //calls the newway point function
        AudioSource audio = GetComponent<AudioSource>(); //get audio component 
        playerHealth = GetComponent<PlayerHealth>(); //get script called playerhealth and store as playerHealth
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                PatrolUpdate();
                break;
            case EnemyState.Chase:
                ChaseUpdate();
                break;
        }


    }

    void PatrolUpdate()
    {
        if (CanSeePlayer()) //checks if the enemy can see player 
        {
            currentState = EnemyState.Chase; //if can see player chase where player went 
        }

        else
        {
            if (agent.remainingDistance < 0.5f) //if the player is close to the waypoint set the next waypoint 
            {
                SetNextWaypoint();
            }

        }
    }



    void ChaseUpdate()
    {
        if (CanSeePlayer()) //if can see the player is yes
        {
            currentState = EnemyState.Chase; //change current state to chase
            agent.destination = lastknownPlayerPosition; //set enemy desitination to player position
        }

        else
        {
            currentState = EnemyState.Patrol; //else if cannot see player, set current state to investigate  
        }
    }



    bool CanSeePlayer()
    {
        foreach (Transform player in PlayerController.allPlayers)
        {
            Vector3 direction = player.position - transform.position; //this is the direction the enemy is facing , is calculated using a vector from the enemy to the player
            float distanceToPlayer = direction.magnitude; //calculates the distance from enemy to player using a staright line

            int layerMask = 8 << LayerMask.NameToLayer("Walls");
            layerMask = ~layerMask; //exclude wall layer


            if (distanceToPlayer <= detectionRange) //checks if the player is within the detection range
            {

                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction.normalized, out hit, detectionRange, layerMask) && hit.collider.CompareTag("Player")) //shoots a raycast from the enemy position in the direction of the player to see if it hit anything and stores it in hit
                {
                    lastknownPlayerPosition = player.position;
                    return true; //if raycast hit player true
                }
            }
        }

        return false; //enemy cannot see the player
    }

    void SetNextWaypoint()
    {
        if (patrolWaypoints.Count == 0) //checks if no waypoints are assigned
        {
            Debug.LogError("No patrol waypoints assigned!"); //if yes then prints to consolse and returns
            return;
        }

        agent.destination = patrolWaypoints[currentWaypointIndex].position; //makes the enemy move towards its current waypoint

        // Increment index for the next waypoint
        currentWaypointIndex = (currentWaypointIndex + 1) % patrolWaypoints.Count; //this ensure that after the last waypoint the enemy will loop back to the first waypoint assigned 

    }
}
