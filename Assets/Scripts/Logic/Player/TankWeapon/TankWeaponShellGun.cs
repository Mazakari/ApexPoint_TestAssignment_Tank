using System.Collections;
using UnityEngine;

public class TankWeaponShellGun : MonoBehaviour, ITankWeapon
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private GameObject _projectilePrefab;

    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _projectileSpeed = 5f;

    private bool _canShoot = true;
    private float _fireRate = 2f;
    private float _currentTimer = 0f;
    

    public void Shoot()
    {
        if (_canShoot)
        {
            Debug.Log("Shell shot");
            _shooter.LaunchProjectile(_projectilePrefab, _damage, _projectileSpeed);
            StartCoroutine(FireColldown());
        }
    }

    private IEnumerator FireColldown()
    {
        _canShoot = false;

        while (_currentTimer <= _fireRate && !_canShoot)
        {
            _currentTimer += Time.deltaTime;
            yield return null;
        }

        _canShoot = true;
        _currentTimer = 0;
    }
}
