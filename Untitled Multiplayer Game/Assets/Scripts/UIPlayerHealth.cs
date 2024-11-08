using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerHealth : MonoBehaviour
{
    public TMP_Text healthText;
    private float currentHealth;
    public GameObject uiStuffOne;
    public GameObject uiStuffTwo;
    public GameObject uiStuffThree;
    public GameObject uiStuffFour;
    public GameObject uiStuffFive;

    public void Start()
    {
        currentHealth = 5;
        UpdateHealth();
        print("Text Health:" + currentHealth);
        //LessHealth(1);
    }

    private void Update()
    {
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
        healthText.text = "" + currentHealth;

        print("Current health now" + currentHealth);
    }
   
}
