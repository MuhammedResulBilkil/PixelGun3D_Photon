using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public void ConnectToPhotonServer()
    {
        if(PhotonNetwork.IsConnected)
            return;
        
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.LogFormat($"{PhotonNetwork.NickName} Connected to Photon Server!");
    }

    public override void OnConnected()
    {
        Debug.Log("Connected to Internet!");
    }
}
