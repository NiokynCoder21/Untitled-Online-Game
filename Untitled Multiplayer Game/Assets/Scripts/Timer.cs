using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class Timer : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnTimeChanged))]
    public float timer = 300f; //how long the timer is
    public ScenceTransition scence; //transion script

    public TMP_Text timerText; // timer text

    private void Start()
    {
        if (isServer)
        {
            InvokeRepeating(nameof(UpdateTimer), 1f, 1f); // Update every second
        }
    }


    [Server]
    private void UpdateTimer()
    {
        if (timer > 0)
        {
            timer -= 1f;
        }

        else
        {
            CancelInvoke(nameof(UpdateTimer));
            
            if (scence != null)
            {
                scence.TransitionToWinScreen(); //this transions 
            }
        }
    }

    private void OnTimeChanged(float oldTime, float newTime)
    {
        UpdateTimerText(newTime); //this updates the text
    }

    private void UpdateTimerText(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}"; //this displays the time in seconds and minues
    }
}
