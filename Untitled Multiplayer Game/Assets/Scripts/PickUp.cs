using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HandTorch")) //if collide with game object check if it has tag hand torch
        {
            //on pick up destroy object 
            //award player what the pick up grants
        }
    }

}
