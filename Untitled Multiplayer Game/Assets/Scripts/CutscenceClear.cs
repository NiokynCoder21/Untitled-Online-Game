using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenceClear : MonoBehaviour
{
    void Update()
    {
        GameObject[] humans = GameObject.FindGameObjectsWithTag("Human"); //looks for all game object with the tag human

        foreach (GameObject human in humans)
        {
            Destroy(human); //destroys all those objects 
        }
    }

}

  

