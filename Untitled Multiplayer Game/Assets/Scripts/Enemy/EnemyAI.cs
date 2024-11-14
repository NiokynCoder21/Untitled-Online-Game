using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 20f; //how far they can see
    private NavMeshAgent agent; //to use later once assigned
    private Vector3 lastKnownPlayerPosition; //this will be the players position 

    public AudioClip groanSound; //the sound the zombies make
    private bool isRunning = false; //whether the sound is playing or not
    public float playInterval; //how often should the sound play

    public enum EnemyState
    {
        Chase,
    }

    private EnemyState currentState; //the current state the enemy is in

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //get the navemesh agent component
        currentState = EnemyState.Chase; // Set initial state to Chase
        AudioSource audio = GetComponent<AudioSource>(); //get the audio source component
        agent.updateRotation = false; //this allows me to control roatation
    }

    void Update()
    {
        if (currentState == EnemyState.Chase) //if current state is chase
        {
            ChaseUpdate(); //chase the player 
        }

        if (!isRunning) //if sound is not playing
        {
            StartCoroutine(PlaySoundEveryFewSeconds()); //play the sound
        }
    }

    void ChaseUpdate()
    {
        if (CanSeePlayer()) //if can see the player
        {
            agent.destination = lastKnownPlayerPosition; // Set enemy's destination to the player's position
        }
    }

    bool CanSeePlayer()
    {
        foreach (Transform player in PlayerController.allPlayers) //get a transform from the player transforms 
        {
            Vector3 direction = player.position - transform.position;
            float distanceToPlayer = direction.magnitude; //calcultes the direction the player is from the enemy

            int layerMask = 8 << LayerMask.NameToLayer("Walls"); //ignore this layer when shooting raycast
            layerMask = ~layerMask;

            if (distanceToPlayer <= detectionRange)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction.normalized, out hit, detectionRange, layerMask) && hit.collider.CompareTag("Player")) //raycast that detects the gameobject with player tag
                {
                    lastKnownPlayerPosition = player.position; //the position it saw is where the player is
                    return true; //it has seen the player so the bool is true
                }
            }
        }

        return false; //it has not seen the player so the bool is false
    }

    IEnumerator PlaySoundEveryFewSeconds()
    {
        isRunning = true;  // this is to ensure it is only called once

        while (true)  // makes the sound play forever
        {
            AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
            audio.clip = groanSound; //assign audio clip as groansound
            audio.Play(); //play clip
            yield return new WaitForSeconds(playInterval); //wait for specifided time before playing sound again
        }
    }

}
