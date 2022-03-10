using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void OnJoinedRoom()
    {
        Debug.LogFormat($"{PhotonNetwork.NickName} joined to {PhotonNetwork.CurrentRoom.Name}!!! Scene: {SceneManager.GetActiveScene().name}");
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat($"{newPlayer.NickName} joined to {PhotonNetwork.CurrentRoom.Name}!!! Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}. Scene: {SceneManager.GetActiveScene().name}");
    }
}
