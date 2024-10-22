using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public struct CharacterMessage : NetworkMessage
    {
        public Race race;
        public string name;
        public Color glassesColor;
    }

    public enum Race
    {
        None,
        Black,
        White,
        Coloured,
        Brown
    }
}
