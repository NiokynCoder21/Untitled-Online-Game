using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class PlayerHealth : NetworkBehaviour
{
    public float maxHealth; //max health in the game
    [SyncVar] public float currentHealth; //current health in the game

    void Start()
    {
        currentHealth = maxHealth;
    }

    [Server]
    public void LessHealth(float loss)
    {
        print("Current Health before: " + currentHealth);
        currentHealth -= loss;
        print("Current Health after: " + currentHealth);

        if (currentHealth < 0)
        {
            print("Dead");
        }
    }

    [ClientRpc]
    void RpcDie()
    {
        gameObject.SetActive(false); // Deactivate the player object upon death
    }

   

    [Command]
    public void MoreHealth(int gain)
    {
        if (!isServer) return;

        if (currentHealth < maxHealth)
        {
            currentHealth += gain;
        }
    }
}
