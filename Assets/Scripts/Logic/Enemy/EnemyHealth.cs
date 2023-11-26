using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    private float _maxHealth;
    private float _currentHealth;

    private float _maxArmor;
    private float _currentArmor;

    public static event Action<GameObject> OnEnemyDestroyed;

    public void SetHealthAndArmor(EnemyStaticData data)
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
        CheckForEnemyDestruction();
    }

    private void CheckForEnemyDestruction()
    {
        if (_currentHealth <= 0)
        {
            SendEnemyDestroyedCallback();
            gameObject.SetActive(false);
        }
    }

    private void CalculateHealthDamage(float damage)
    {
        //здоровье=здоровье-урон* защита (0Е1).
        _currentHealth -= damage * _currentArmor;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        Debug.Log($"Enemy _currentHealth = {_currentHealth}");
    }
    private void SendEnemyDestroyedCallback() =>
        OnEnemyDestroyed?.Invoke(gameObject);
}
