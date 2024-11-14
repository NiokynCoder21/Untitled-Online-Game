using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyHealth : NetworkBehaviour
{
    public float maxEnergy = 200; //max health in the game
    public float currentEnergy; //current health in the game
    public GameObject enemy; //the enemy game object
    public int scorePoints; //how kills the players gets 

    void Start()
    {
        currentEnergy = maxEnergy; //set current health to max health
    }



    [Server] 
    public void TakeDamage(float damageAmount)
    {
        currentEnergy -= damageAmount; //reduces the enemeies health

        if (currentEnergy <= 0)
        {
            HandleEnemyDeath();
        }
    }

    [Server]
    public void Kamikazze(float damage) //this is for when the enemies kill themselves
    {
        currentEnergy -= damage; //reduces the enemeies health

        if (currentEnergy <= 0)
        {
            NetworkServer.Destroy(enemy); //destroy the game object over the network
        }
    }

    [Server]
    private void HandleEnemyDeath()
    {
        ScoreManager scoreManager = GameObject.FindWithTag("Score")?.GetComponent<ScoreManager>(); //get a game object with tag score and store as scoreManager

        if (scoreManager != null)
        {
            scoreManager.Points(scorePoints); //assign points to the players
        }

        // Destroy the enemy object across the network
        NetworkServer.Destroy(enemy);
    }

}
