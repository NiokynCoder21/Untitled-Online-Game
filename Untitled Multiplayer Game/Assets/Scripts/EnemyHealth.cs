using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxEnergy = 200; //max health in the game
    public float currentEnergy; //current health in the game
    public AudioClip hurtSound;
    public float pushBackForce;

    void Start()
    {
        currentEnergy = maxEnergy; //set current health to max health
    }

    public void LossEnergy(float energy) //function for when the player loses energy
    {
        currentEnergy -= energy; //this reduces energy from current energy and assigns the current energy
        AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio
        audio.clip = hurtSound; //make the audio clip be emptygunsound
        audio.Play(); //play the audio clip be emptygunsound

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 pushBackDirection = -transform.forward; // direction to push back the player (opposite of forward direction)
            rb.AddForce(pushBackDirection * pushBackForce, ForceMode.Impulse); // apply an impulse force to push back
        }

        if (currentEnergy <= 0) //if current energy is less than or equal to zero
        {
            Destroy(this);
        }
    }

    //Brakeys.(2020, Febuary 9). How to make a Health bar in Unity![Video] https://www.youtube.com/watch?v=BLfNP4Sc_iA&list=PLt1E2jJc5nDj6KQi6BVJElz3vqFmg-B8I&index=4 
}
