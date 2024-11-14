using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ScenceTransition : NetworkBehaviour
{
        [Server]
    public void TransitionToWinScreen()
    {
        NetworkManager.singleton.ServerChangeScene("Win"); //changes server scence to win
    }

    public void TranstionLose()
    {
        NetworkManager.singleton.ServerChangeScene("Lose"); //changes server scence to lose
    }

    // Optional: You can call this from anywhere, just make sure it's called on the server
    [Command]
    public void CmdTransitionToWinScreen()
    {
        if (isServer) //if running on server
        {
            TransitionToWinScreen(); //changes server scence to win
        }
    }

    [Command]
    public void CmdLose()
    {
        if (isServer) //if running on server
        {
            TranstionLose(); //changes server scence to lose
        }
    }

}
