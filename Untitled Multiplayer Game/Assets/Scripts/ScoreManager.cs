using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class ScoreManager : NetworkBehaviour
{
    public TMP_Text scoreText;
    public int score;
    public AudioClip[] scoreSounds;
    public GameObject scoreStuff;

    void Start()
    {
        if (!isLocalPlayer)
        {
            scoreStuff.gameObject.SetActive(false);
            return;
        }

        score = 0;
        UpdateScoreText();
    }


    public void Points(int more)
    {
        if (!isLocalPlayer) return;

        score += more;
        UpdateScoreText();

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

        scoreText.text = "Score :" + score; //update text to show the current score
    }

}
