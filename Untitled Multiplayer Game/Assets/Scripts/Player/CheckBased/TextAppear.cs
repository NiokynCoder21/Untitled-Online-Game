using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TextAppear : NetworkBehaviour
{
    public GameObject magPickUpText; //mag pickup text
    public Weapon weapon; //weapon script reference
    public AudioClip pickUpSound; //pick up sound

    public void OnTriggerEnter(Collider other)
    {
        if (!isLocalPlayer) return;

        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(true); //show the text

            if (weapon != null)
            {
                weapon.SetCanPickUp(true); //player can pick up mag

                if (weapon.hasPickedUp == true)
                {
                    weapon.SetCanPickUp(false); //player cannot pick up mag
                    magPickUpText.gameObject.SetActive(false); //hide text
                    weapon.hasPickedUp = false; //set bool
                    AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
                    audio.clip = pickUpSound; //make the audio clip be emptygunsound
                    audio.Play(); //play the audio clip be emptygunsound
                    NetworkServer.Destroy(other.gameObject); //destroy the object across the server
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isLocalPlayer) return;

        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(true); //show the text

            if (weapon != null)
            {
                weapon.SetCanPickUp(true); //player can pick up mag

                if (weapon.hasPickedUp == true)
                {
                    weapon.SetCanPickUp(false); //player cannot pick up mag
                    magPickUpText.gameObject.SetActive(false); //hide text
                    weapon.hasPickedUp = false; //set bool
                    AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
                    audio.clip = pickUpSound; //make the audio clip be emptygunsound
                    audio.Play(); //play the audio clip be emptygunsound
                    NetworkServer.Destroy(other.gameObject); //destroy the object across the server
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Mag"))
        {
            magPickUpText.gameObject.SetActive(false); //show the text

            if (weapon != null)
            {
                weapon.SetCanPickUp(false); //player can pick up mag
            }

            if (weapon.hasPickedUp == true)
            {
                weapon.SetCanPickUp(false); //player cannot pick up mag
                magPickUpText.gameObject.SetActive(false); //hide text
                weapon.hasPickedUp = false; //set bool
                AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
                audio.clip = pickUpSound; //make the audio clip be emptygunsound
                audio.Play(); //play the audio clip be emptygunsound
                NetworkServer.Destroy(other.gameObject); //destroy the object across the server
            }
        }
    }

   
}
