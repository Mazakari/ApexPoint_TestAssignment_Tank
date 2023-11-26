using System.Collections;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private int _playerLayer;
    private float _damage = 1f;

    private bool _canDamage = true;
    private float _fireRate = 0.1f;
    private float _currentTimer = 0f;

    private IHealth _playerHealth;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            HitPlayer(collision);
        }
    }

    public void SetDamage(float damage) => 
        _damage = damage;

    private void HitPlayer(Collision collision)
    {
        if (_playerHealth == null)
        {
            SetPlayerHealthReference(collision);
        }

        Damage(_playerHealth);
    }

    private void Damage(IHealth playerHealth)
    {
        try
        {
            if (_canDamage)
            {
                Debug.Log("Enemy damaged player");
                playerHealth.GetDamage(_damage);
                StartCoroutine(DamageColldown());
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private IEnumerator DamageColldown()
    {
        _canDamage = false;

        while (_currentTimer <= _fireRate && !_canDamage)
        {
            _currentTimer += Time.deltaTime;
            yield return null;
        }

        _canDamage = true;
        _currentTimer = 0;
    }

    private void SetPlayerHealthReference(Collision collision) =>
       _playerHealth = collision.gameObject.transform.root.GetComponent<IHealth>();
}
