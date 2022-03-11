using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviourPunCallbacks
{
    public static GameController Instance { get; private set; }

    private const string GameLauncherScene = "GameLauncherScene";
    
    [SerializeField] private GameObject _playerPrefab;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (_playerPrefab != null)
            {
                float randomPoint = Random.Range(-20f, 20f);
                
                PhotonNetwork.Instantiate(_playerPrefab.name, new Vector3(randomPoint, 0f, randomPoint), Quaternion.identity);
            }
            
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.LogFormat($"{PhotonNetwork.NickName} joined to {PhotonNetwork.CurrentRoom.Name}!!! Scene: {SceneManager.GetActiveScene().name}");
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat($"{newPlayer.NickName} joined to {PhotonNetwork.CurrentRoom.Name}!!! Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}. Scene: {SceneManager.GetActiveScene().name}");
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(GameLauncherScene);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
