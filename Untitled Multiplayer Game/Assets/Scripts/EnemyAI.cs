using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 20f;
    private NavMeshAgent agent;
    private Vector3 lastKnownPlayerPosition;
    public float range = 200f;
    public PlayerHealth playerHealth;

    public AudioClip groanSound;
    private bool isRunning = false;
    public float playInterval;

    public enum EnemyState
    {
        Chase,
    }

    private EnemyState currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = EnemyState.Chase; // Set initial state to Chase
        AudioSource audio = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>();
        agent.updateRotation = false; //this allows me to control roatation
    }

    void Update()
    {
        if (currentState == EnemyState.Chase)
        {
            ChaseUpdate();
        }

        if (!isRunning)
        {
            StartCoroutine(PlaySoundEveryFewSeconds());
        }
    }

    void ChaseUpdate()
    {
        if (CanSeePlayer())
        {
            agent.destination = lastKnownPlayerPosition; // Set enemy's destination to the player's last known position
        }
    }

    bool CanSeePlayer()
    {
        foreach (Transform player in PlayerController.allPlayers)
        {
            Vector3 direction = player.position - transform.position;
            float distanceToPlayer = direction.magnitude;

            int layerMask = 8 << LayerMask.NameToLayer("Walls");
            layerMask = ~layerMask;

            if (distanceToPlayer <= detectionRange)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction.normalized, out hit, detectionRange, layerMask) && hit.collider.CompareTag("Player"))
                {
                    lastKnownPlayerPosition = player.position;
                    return true;
                }
            }
        }

        return false;
    }

    IEnumerator PlaySoundEveryFewSeconds()
    {
        isRunning = true;  // Set the flag to prevent multiple calls

        while (true)  // Keep the coroutine running indefinitely
        {
            AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
            audio.clip = groanSound;
            audio.Play();
            yield return new WaitForSeconds(playInterval);  // Wait for the specified interval
        }
    }

}
