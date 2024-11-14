using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class UIPlayerHealth : NetworkBehaviour
{
    public TMP_Text healthText;
    private float currentHealth;
    public GameObject uiManagerHealth;
    public AudioClip hurtClip;
    public ScenceTransition scence;
    public GameObject player;

    public void Start()
    {
        if (!isLocalPlayer)
        {
            uiManagerHealth.gameObject.SetActive(false);
            return;
        }

        currentHealth = 15;
        UpdateHealth();
    }


    public void LessHealth(float loss)
    {
        if (!isLocalPlayer) return;

        currentHealth -= loss;
        UpdateHealth();
        AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
        audio.clip = hurtClip;
        audio.Play();

        if (currentHealth == 0)
        {
            if (scence != null)
            {
                scence.TranstionLose();
                Destroy(player);
            }
        }
    }


    public void UpdateHealth()
    {
        if (!isLocalPlayer) return;

        healthText.text = "" + currentHealth;

    }
   
}
