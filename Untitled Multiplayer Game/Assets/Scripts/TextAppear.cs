using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    public GameObject magPickUpText;
    public Weapon weapon;
    public AudioClip pickUpSound;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(true);

            if (weapon != null)
            {
                weapon.SetCanPickUp(true);

                if (weapon.hasPickedUp == true)
                {
                    weapon.SetCanPickUp(false);
                    magPickUpText.gameObject.SetActive(false);
                    weapon.hasPickedUp = false;
                    AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
                    audio.clip = pickUpSound; //make the audio clip be emptygunsound
                    audio.Play(); //play the audio clip be emptygunsound
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(true);

            if (weapon != null)
            {
                weapon.SetCanPickUp(true);

                if (weapon.hasPickedUp == true)
                {
                    weapon.SetCanPickUp(false);
                    magPickUpText.gameObject.SetActive(false);
                    weapon.hasPickedUp = false;
                    AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
                    audio.clip = pickUpSound; //make the audio clip be emptygunsound
                    audio.Play(); //play the audio clip be emptygunsound
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(false);

            if (weapon != null)
            {
                weapon.SetCanPickUp(false);
            }

            if (weapon.hasPickedUp == true)
            {
                weapon.SetCanPickUp(false);
                magPickUpText.gameObject.SetActive(false);
                weapon.hasPickedUp = false;
                AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
                audio.clip = pickUpSound; //make the audio clip be emptygunsound
                audio.Play(); //play the audio clip be emptygunsound
                Destroy(other.gameObject);
            }
        }
    }
}
