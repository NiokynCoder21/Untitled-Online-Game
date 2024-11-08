using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public PlayerHealth health;
    public float currentHealth;
    public float maxHealth;
    public GameObject uiStuffOne;
    public GameObject uiStuffTwo;
    public GameObject uiStuffThree;
    public GameObject uiStuffFour;
    public GameObject uiStuffFive;

    public void Start()
    {
        currentHealth = maxHealth;
        UpdateHealth();
        print("Text Health:" + health.currentHealth);
    }

    private void Update()
    {
        UpdateHealth();

        if (currentHealth == 4)
        {
            print("first done");

            if (uiStuffFive != null)
            {
                uiStuffFive.gameObject.SetActive(false);
            }
            
        }

        if (currentHealth == 3)
        {
            print("second done");

            if (uiStuffFour != null)
            {
                uiStuffFour.gameObject.SetActive(false);
            }
        }

        if (currentHealth == 2)
        {
            if (uiStuffThree != null)
            {
                uiStuffThree.gameObject.SetActive(false);
            }
        }

        if (currentHealth == 1)
        {
            if (uiStuffTwo != null)
            {
                uiStuffTwo.gameObject.SetActive(false);
            }
        }

    }

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


    public void UpdateHealth()
    {
       // healthText.text = "" + health;
        healthText.text = $"Health: {currentHealth}";
    }
   
}
