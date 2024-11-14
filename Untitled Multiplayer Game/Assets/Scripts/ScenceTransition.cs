using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ScenceTransition : NetworkBehaviour
{
    public UIPlayerHealth health;
    public bool playerDead = false;

     [Server]
    public void TransitionToWinScreen()
    {
        NetworkManager.singleton.ServerChangeScene("Win"); //changes server scence to win
    }

    [Server]
    public void TranstionLose()
    {
        NetworkManager.singleton.ServerChangeScene("Lose"); //changes server scence to lose
    }

    [Command]
    public void CmdTransitionToWinScreen()
    {
        if (isServer) //if running on server
        {
            TransitionToWinScreen(); //changes server scence to win
        }
    }

    private void Update()
    {
        if (playerDead == true)
        {
            TranstionLose();
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
