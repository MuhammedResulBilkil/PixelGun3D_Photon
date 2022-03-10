using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] private AudioListener _audioListener;
    [SerializeField] private TextMeshProUGUI _playerNameText;

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
        
        SetPlayerUI();
    }

    private void SetPlayerUI()
    {
        if (_playerNameText != null)
        {
            _playerNameText.text = photonView.Owner.NickName;
        }
    }
}
