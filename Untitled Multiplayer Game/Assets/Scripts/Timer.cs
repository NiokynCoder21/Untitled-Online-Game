using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class Timer : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnTimeChanged))]
    public float timer = 300f; // Start with a 5-minute timer (300 seconds)
    public ScenceTransition scence;

    public TMP_Text timerText; // Assign TimerText in the Inspector

    private void Start()
    {
        if (isServer)
        {
            InvokeRepeating(nameof(UpdateTimer), 1f, 1f); // Update every second
        }
    }

    // Only runs on the server
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
                scence.TransitionToWinScreen();
            }
        }
    }

    // This method is called whenever the timer SyncVar changes
    private void OnTimeChanged(float oldTime, float newTime)
    {
        UpdateTimerText(newTime);
    }

    private void UpdateTimerText(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
