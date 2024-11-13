using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyHealth : NetworkBehaviour
{
    public float maxEnergy = 200; //max health in the game
    public float currentEnergy; //current health in the game
    public GameObject enemy;
    public int scorePoints;

    void Start()
    {
        currentEnergy = maxEnergy; //set current health to max health
    }



    [Server] // Ensure this method only runs on the server
    public void TakeDamage(float damageAmount)
    {
        // Reduce the enemy's energy
        currentEnergy -= damageAmount;

        // Check if energy is depleted
        if (currentEnergy <= 0)
        {
            HandleEnemyDeath();
            print("dead");
        }
    }

    [Server]
    public void Kamikazze(float damage)
    {
        currentEnergy -= damage;
        AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio

        if (currentEnergy <= 0)
        {
            NetworkServer.Destroy(enemy);
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
