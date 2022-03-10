using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] private AudioListener _audioListener;

    private MovementController _movementController;
    
    private void Awake()
    {
        _movementController = GetComponent<MovementController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine && PhotonNetwork.IsConnected)
        {
            _movementController.enabled = true;
            _fpsCamera.enabled = true;
            _audioListener.enabled = true;
        }
        else
        {
            _movementController.enabled = false;
            _fpsCamera.enabled = false;
            _audioListener.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
