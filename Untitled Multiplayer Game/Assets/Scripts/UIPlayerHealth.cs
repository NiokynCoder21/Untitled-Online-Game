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

    public void Start()
    {
        if (!isLocalPlayer)
        {
            uiManagerHealth.gameObject.SetActive(false);
            return;
        }

        currentHealth = 10;
        UpdateHealth();
        print("Text Health:" + currentHealth);
    }


    public void LessHealth(float loss)
    {
        if (!isLocalPlayer) return;

        currentHealth -= loss;
        UpdateHealth();
        print("Current Health after: " + currentHealth);

        if (currentHealth == 0)
        {
            print("death");
        }
    }


    public void UpdateHealth()
    {
        if (!isLocalPlayer) return;

        healthText.text = "" + currentHealth;

        print("Current health now" + currentHealth);
    }
   
}
