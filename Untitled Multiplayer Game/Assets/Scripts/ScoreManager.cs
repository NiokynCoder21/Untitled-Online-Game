using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    public int score;
    public AudioClip[] scoreSounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        score = 0;
        UpdateScoreText();
    }


    public void Points(int more)
    {
        score += more;
        UpdateScoreText();

        AudioSource audio = GetComponent<AudioSource>(); //get component audio source and store as audio

        if (scoreSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, scoreSounds.Length); // pick a random index
            audio.clip = scoreSounds[randomIndex]; // assign a random clip
            audio.Play(); // play the randomly selected sound
        }
    }

   
    private void UpdateScoreText()
    {
        scoreText.text = "Score :" + score; //update text to show the current score
    }

}
