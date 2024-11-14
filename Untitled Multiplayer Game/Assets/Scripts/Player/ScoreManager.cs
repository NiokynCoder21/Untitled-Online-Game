using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class ScoreManager : NetworkBehaviour
{
    public TMP_Text scoreText; //the score text
    public int score; //the score amount
    public AudioClip[] scoreSounds; //the sounds that play when player gets a kill
    public GameObject scoreStuff; //this is the score game object

    void Start()
    {
        if (!isLocalPlayer)
        {
            scoreStuff.gameObject.SetActive(false);
            return;
        }

        score = 0; //set inital score to zero
        UpdateScoreText(); //updadate text to reflect score 
    }


    public void Points(int more)
    {
        if (!isLocalPlayer) return;

        score += more; //increase the score
        UpdateScoreText(); //update text

        AudioSource audio1 = GetComponent<AudioSource>(); //get component audio source and store as audio

        if (scoreSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, scoreSounds.Length); // pick a random index
            audio1.clip = scoreSounds[randomIndex]; // assign a random clip
            audio1.Play(); // play the randomly selected sound
        }
    }

   
    private void UpdateScoreText()
    {
        if (!isLocalPlayer) return;

        scoreText.text = "Killed :" + score; //update text to show the current score
    }

}
