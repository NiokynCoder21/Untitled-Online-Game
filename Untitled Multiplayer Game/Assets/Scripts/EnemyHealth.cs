using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxEnergy = 200; //max health in the game
    public float currentEnergy; //current health in the game
    public AudioClip hurtSound;
    public AudioClip zombieDeadSound;
    public GameObject enemy;
    public ScoreManager score;
    public int scorePoints;

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

        if (currentEnergy <= 0) //if current energy is less than or equal to zero
        {
            ScoreManager.Instance.Points(scorePoints);
            Destroy(enemy);
        }
    }

    //Brakeys.(2020, Febuary 9). How to make a Health bar in Unity![Video] https://www.youtube.com/watch?v=BLfNP4Sc_iA&list=PLt1E2jJc5nDj6KQi6BVJElz3vqFmg-B8I&index=4 
}
