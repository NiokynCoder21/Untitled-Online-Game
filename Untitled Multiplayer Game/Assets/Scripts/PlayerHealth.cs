using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using TMPro;

public class PlayerHealth : NetworkBehaviour
{
    public float maxHealth; //max health in the game
    [SyncVar]public float currentHealth; //current health in the game
    public float damageAmount = 1;
    public TMP_Text healthText;

    [Server]
    public void LessHealth(float loss)
    {
        print("Current Health before: " + currentHealth);
        currentHealth -= loss;
        print("Current Health after: " + currentHealth);

        if (currentHealth == 0)
        {
            print("death");
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
