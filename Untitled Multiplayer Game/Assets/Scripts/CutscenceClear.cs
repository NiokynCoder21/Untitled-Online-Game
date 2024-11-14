using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenceClear : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        // Find all GameObjects with the tag "Human"
        GameObject[] humans = GameObject.FindGameObjectsWithTag("Human");

        // Loop through each GameObject and destroy it
        foreach (GameObject human in humans)
        {
            Destroy(human);
        }
    }

}

  

