using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerHurt : NetworkBehaviour
{
    public bool hasTaken = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isLocalPlayer) return;

        if (collision.gameObject.CompareTag("Zom"))
        {
            if (hasTaken == true)
            {
                CmdCollision(collision.gameObject);
                hasTaken = false;
            }
   
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!isLocalPlayer) return;

        if (collision.gameObject.CompareTag("Zom"))
        {
            if (hasTaken == false)
            {
                CmdCollision(collision.gameObject);
                hasTaken = false;
            }
        }
    }

    [Command]
    void CmdCollision(GameObject zomObject)
    {
        NetworkServer.Destroy(zomObject);
    }

    public void SetHasTaken(bool state)
    {
        hasTaken = state;
    }
}
