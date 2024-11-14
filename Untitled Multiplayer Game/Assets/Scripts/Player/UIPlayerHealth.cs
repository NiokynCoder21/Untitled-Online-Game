using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class UIPlayerHealth : NetworkBehaviour
{
    public TMP_Text healthText; //health text
    private float currentHealth; //stored for when we need to assign health to the player
    public GameObject uiManagerHealth; //this is ui game object
    public AudioClip hurtClip; //hurt clip sound
    public ScenceTransition scence; //reference to scence script
    public GameObject player; //player game object

    public void Start()
    {
        if (!isLocalPlayer)
        {
            uiManagerHealth.gameObject.SetActive(false);
            return;
        }

        currentHealth = 10; //set the current health
        UpdateHealth(); //update text
    }


    public void LessHealth(float loss)
    {
        if (!isLocalPlayer) return;

        currentHealth -= loss; //reduce player health
        UpdateHealth(); //update text
        AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
        audio.clip = hurtClip; //assign hurt clip to clip
        audio.Play(); //play clip

        if (currentHealth == 0)
        {
            if (scence != null)
            {
                scence.TranstionLose(); //transition all players to new scence
                Destroy(player); //if player is not transitioned destroy them instead
            }
        }
    }


    public void UpdateHealth()
    {
        if (!isLocalPlayer) return;

        healthText.text = "" + currentHealth; //makes the health text show the current health

    }
   
}
