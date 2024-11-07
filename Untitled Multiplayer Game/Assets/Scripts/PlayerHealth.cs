using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class PlayerHealth : NetworkBehaviour
{
    public float maxHealth; //max health in the game
    [SyncVar] public float currentHealth; //current health in the game
    public HealthBars healthBar; //reference to the healthBar game object

    void Start()
    {
        currentHealth = maxHealth; //set current health to max health
        healthBar.SetMaxHealth(maxHealth); //set health bar to max health  
    }

    public void LessHealth(float loss)
    {
        if (!isServer) return;

        if (currentHealth > 0)
        {
            currentHealth -= loss;
            healthBar.SetHealth(currentHealth); //set healthbar to current energy

            if (currentHealth < 0)
            {
                RpcDie();
            }
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
            healthBar.SetHealth(maxHealth); //set healthbar to current energy
        }
    }
}
