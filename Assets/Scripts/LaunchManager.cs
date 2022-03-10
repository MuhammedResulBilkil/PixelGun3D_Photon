using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _enterGamePanel;
    [SerializeField] private GameObject _connectionStatusPanel;
    [SerializeField] private GameObject _lobbyPanel;

    #region Unity Methods

    private void Start()
    {
        _enterGamePanel.SetActive(true);
        _connectionStatusPanel.SetActive(false);
        _lobbyPanel.SetActive(false);
    }

    #endregion
    
    #region Public Methods

    public void ConnectToPhotonServer()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.LogError("You already connected to the photon server!");
            return;
        }

        if (PhotonNetwork.NickName.Length == 0)
        {
            Debug.LogError("NickName can not be empty!!!");
            return;
        }


        PhotonNetwork.ConnectUsingSettings();

        _connectionStatusPanel.SetActive(true);
        _enterGamePanel.SetActive(false);
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #endregion

    #region Private Methods

    private void CreateAndJoinRoom()
    {
        string randomRoomName = $"Room {Random.Range(0, 100000)}";

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #endregion
    
    
    #region Photon CallBacks

    public override void OnConnectedToMaster()
    {
        Debug.LogFormat($"{PhotonNetwork.NickName} Connected to Photon Server!");

        _connectionStatusPanel.SetActive(false);
        _lobbyPanel.SetActive(true);
    }

    public override void OnConnected()
    {
        Debug.Log("Connected to Internet!");
    }

    public override void OnJoinedRoom()
    {
        Debug.LogFormat($"{PhotonNetwork.NickName} joined to {PhotonNetwork.CurrentRoom.Name}!!!");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        
        CreateAndJoinRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat($"{newPlayer.NickName} joined to {PhotonNetwork.CurrentRoom.Name}!!! Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}.");
    }

    #endregion
    
}
