using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

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

    #endregion
    
}
