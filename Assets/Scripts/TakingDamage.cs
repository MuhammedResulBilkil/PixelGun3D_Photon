using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class TakingDamage : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Image _healthBarImage;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;

        _healthBarImage.fillAmount = _currentHealth / _maxHealth;
    }

    [PunRPC]
    public void TakeDamage(float damageAmount)
    {
        float tempHealth = _currentHealth - damageAmount;

        _currentHealth = Mathf.Clamp(tempHealth, 0f, 100f);
        _healthBarImage.fillAmount = _currentHealth / _maxHealth;
        
        Debug.LogFormat($"Health = {_currentHealth}");

        if (_currentHealth <= 0f)
        {
            //Die
            Die();
        }
    }

    public void Die()
    {
        
    }
}