using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiter : MonoBehaviour
{
    public float waitTime; //how long it should wait

    void Start()
    {
        StartCoroutine(QuitAfterDelay());
    }

    IEnumerator QuitAfterDelay()
    {
        yield return new WaitForSeconds(waitTime); //wait 

        Application.Quit(); //quits the game
    }
}
