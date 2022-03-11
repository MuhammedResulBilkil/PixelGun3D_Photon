using System;
using Photon.Pun;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    [PunRPC]
    public void TakeDamage(float damageAmount)
    {
        float tempHealth = _health - damageAmount;

        _health = Mathf.Clamp(tempHealth, 0f, 100f);
        Debug.LogFormat($"Health = {_health}");
    }
}