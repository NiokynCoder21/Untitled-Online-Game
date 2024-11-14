using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerCustom : NetworkManager
{
    [HideInInspector] public string playerName; // This will store the player's name entered in the lobby

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        // Add custom player setup here, if needed
    }
}
