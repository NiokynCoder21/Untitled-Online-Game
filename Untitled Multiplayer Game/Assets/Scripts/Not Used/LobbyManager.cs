using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public NetworkManager networkManager;              // Reference to the NetworkManager
    public Button hostButton;                          // Button to host a game
    public Button joinButton;                          // Button to join a game
    public string mainLevelSceneName = "SampleScene";    // Name of the main game level scene
    public NetworkManagerCustom networkManagerCustom;
    public string playerName;

    void Start()
    {
        hostButton.onClick.AddListener(OnHostClicked); // Set up host button
        joinButton.onClick.AddListener(OnJoinClicked); // Set up join button
    }

    void OnHostClicked()
    {
        networkManagerCustom.StartHost();
        SceneManager.LoadScene(1);
    }

    void OnJoinClicked()
    {
        networkManagerCustom.StartClient();
        SceneManager.LoadScene(1);
    }
}
