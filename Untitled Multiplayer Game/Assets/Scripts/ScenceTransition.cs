using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ScenceTransition : NetworkBehaviour
{
    public bool hasDisabled = false;

        [Server]
    public void TransitionToWinScreen()
    {
        NetworkManager.singleton.ServerChangeScene("Win");
    }

    public void TranstionLose()
    {
        NetworkManager.singleton.ServerChangeScene("Lose");
    }

    // Optional: You can call this from anywhere, just make sure it's called on the server
    [Command]
    public void CmdTransitionToWinScreen()
    {
        if (isServer)
        {
            TransitionToWinScreen();
        }
    }

    [Command]
    public void CmdLose()
    {
        if (isServer)
        {
            TranstionLose();
        }
    }

}
