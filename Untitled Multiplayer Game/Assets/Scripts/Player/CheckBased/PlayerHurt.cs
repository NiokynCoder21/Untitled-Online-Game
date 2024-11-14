using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerHurt : NetworkBehaviour
{
    public bool hasTaken = false; //where health has been taken from the player

    private void OnCollisionEnter(Collision collision)
    {
        if (!isLocalPlayer) return; //this to ensure that it works for client it is on only

        if (collision.gameObject.CompareTag("Zom"))
        {
            if (hasTaken == true)
            {
                CmdCollision(collision.gameObject); //destroy the enemy game object
                hasTaken = false; //reset bool
            }
   
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!isLocalPlayer) return; //this to ensure that it works for client it is on only

        if (collision.gameObject.CompareTag("Zom"))
        {
            if (hasTaken == false)
            {
                CmdCollision(collision.gameObject);  //destroy the enemy game object
                hasTaken = false; //reset bool
            }
        }
    }

    [Command]
    void CmdCollision(GameObject zomObject)
    {
        NetworkServer.Destroy(zomObject); //destroys this object server wide
    }

    public void SetHasTaken(bool state) //allows me to set this bool in other script
    {
        hasTaken = state;
    }
}
