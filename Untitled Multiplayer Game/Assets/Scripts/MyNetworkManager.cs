using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    // List of player prefabs (drag and drop in Inspector)
    public List<GameObject> playerPrefabs = new List<GameObject>();

    // List of spawn points (drag and drop in Inspector)
    public List<Transform> spawnPoints = new List<Transform>();


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // Check if there are enough prefabs and spawn points
        if (numPlayers < playerPrefabs.Count && numPlayers < spawnPoints.Count)
        {
            // Select the prefab and spawn point for the player joining
            GameObject playerPrefab = playerPrefabs[numPlayers];
            Transform spawnPoint = spawnPoints[numPlayers];

            // Instantiate the player prefab at the spawn point
            GameObject playerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

            // Register the player to the network connection
            NetworkServer.AddPlayerForConnection(conn, playerInstance);
        }

        else
        {
            Debug.LogWarning("Not enough prefabs or spawn points assigned in the lists.");
        }
    }
}
