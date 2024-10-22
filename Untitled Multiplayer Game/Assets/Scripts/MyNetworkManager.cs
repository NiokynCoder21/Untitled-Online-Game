using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public GameObject PlayerPrefab2;  // Prefab for Player 2

    public override void OnStartServer()
    {
        base.OnStartServer();
        // We do not need to register any custom message handlers since the server decides
    }

    // When a client connects, assign them a player prefab based on their connection order
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject gameobject;

        if (numPlayers == 0)
        {
            // This is Player 1, spawn Prefab 1 (the default `playerPrefab`)
            gameobject = Instantiate(playerPrefab);  // `playerPrefab` is from the NetworkManager
            Debug.Log("Spawning Player 1 with Prefab 1");
        }
        else if (numPlayers == 1)
        {
            // This is Player 2, spawn Prefab 2
            gameobject = Instantiate(PlayerPrefab2);  // Player 2 prefab
            Debug.Log("Spawning Player 2 with Prefab 2");
        }
        else
        {
            Debug.LogError("More than 2 players connected!");
            return;
        }

        // Add the player object to the connection
        NetworkServer.AddPlayerForConnection(conn, gameobject);
    }
}
