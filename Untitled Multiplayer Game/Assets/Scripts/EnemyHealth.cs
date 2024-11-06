using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyHealth : NetworkBehaviour
{
    public float maxEnergy = 200; //max health in the game
    public float currentEnergy; //current health in the game
    public AudioClip hurtSound;
    public AudioClip zombieDeadSound;
    public GameObject enemy;
    public int scorePoints;

    void Start()
    {
        currentEnergy = maxEnergy; //set current health to max health
    }

    /*public void LossEnergy(float energy) //function for when the player loses energy
    {
        currentEnergy -= energy; //this reduces energy from current energy and assigns the current energy
        AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
        audio.clip = hurtSound; //make the audio clip be emptygunsound
        audio.Play(); //play the audio clip be emptygunsound

        GameObject player = GameObject.FindWithTag("Score");

        if (player != null)
        {
            ScoreManager score = player.GetComponent<ScoreManager>();

            if (currentEnergy <= 0) //if current energy is less than or equal to zero
            {
                if (score != null)
                {
                    score.Points(scorePoints);
                    Destroy(enemy);
                }
            }
        }
    }*/

    [Server] // Ensure this method only runs on the server
    public void TakeDamage(float damageAmount)
    {
        // Reduce the enemy's energy
        currentEnergy -= damageAmount;
        AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
        audio.clip = hurtSound;
        audio.Play();
        print("hit");

        // Check if energy is depleted
        if (currentEnergy <= 0)
        {
            HandleEnemyDeath();
            print("dead");
        }
    }

    [Server]
    private void HandleEnemyDeath()
    {
        // Update the score through ScoreManager
        ScoreManager scoreManager = GameObject.FindWithTag("Score")?.GetComponent<ScoreManager>();

        if (scoreManager != null)
        {
            scoreManager.Points(scorePoints);
        }

        // Destroy the enemy object across the network
        NetworkServer.Destroy(enemy);
    }

    //Brakeys.(2020, Febuary 9). How to make a Health bar in Unity![Video] https://www.youtube.com/watch?v=BLfNP4Sc_iA&list=PLt1E2jJc5nDj6KQi6BVJElz3vqFmg-B8I&index=4 
}
