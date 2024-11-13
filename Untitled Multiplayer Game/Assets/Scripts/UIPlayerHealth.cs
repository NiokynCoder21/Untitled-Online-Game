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

    public void Start()
    {
        if (!isLocalPlayer)
        {
            uiManagerHealth.gameObject.SetActive(false);
            return;
        }

        currentHealth = 10;
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
            print("death");
        }
    }


    public void UpdateHealth()
    {
        if (!isLocalPlayer) return;

        healthText.text = "" + currentHealth;

    }
   
}
