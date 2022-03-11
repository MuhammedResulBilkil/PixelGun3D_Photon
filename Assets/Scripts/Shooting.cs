using System;
using Photon.Pun;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    private const string TakeDamage = "TakeDamage";
    
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] private float _fireRate;

    private float _fireTimer;
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(!_photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        
        if (_fireTimer < _fireRate)
            _fireTimer += Time.deltaTime;

        if (Input.GetButton("Fire1") && _fireTimer > _fireRate)
        {
            //Reset _fireTimer
            _fireTimer = 0.0f;

            RaycastHit hit;
            Ray ray = _fpsCamera.ViewportPointToRay(Vector2.one * 0.5f);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log(hit.transform.name);
                
                if (hit.transform.CompareTag("Player"))
                {
                    PhotonView enemyPhotonView = hit.transform.GetComponent<PhotonView>();
                    
                    if(!enemyPhotonView.IsMine)
                        enemyPhotonView.RPC(TakeDamage, RpcTarget.AllBuffered, 10f);

                }
            }
        }
    }
}