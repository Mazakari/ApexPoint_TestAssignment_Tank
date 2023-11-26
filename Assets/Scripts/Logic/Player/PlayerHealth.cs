using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private float _maxHealth;
    private float _currentHealth;

    private float _maxArmor;
    private float _currentArmor;

    public static event Action OnPlayerDestroyed;

    public void SetHealthAndArmor(PlayerTankStaticData data)
    {
        try
        {
            _maxHealth = data.health;
            _currentHealth = _maxHealth;

            _maxArmor = data.armor;
            _currentArmor = _maxArmor;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    public void GetDamage(float damage)
    {
        CalculateHealthDamage(damage);
        CheckForPlayerDestruction();
    }

    private void CheckForPlayerDestruction()
    {
        if (_currentHealth <= 0)
        {
            SendPlayerDestroyedCallback();
        }
    }

    private void CalculateHealthDamage(float damage)
    {
        //здоровье=здоровье-урон* защита (0Е1).
        _currentHealth -= damage * _currentArmor;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        Debug.Log($"Player _currentHealth = {_currentHealth}");
    }
    private static void SendPlayerDestroyedCallback() => 
        OnPlayerDestroyed?.Invoke();
}
