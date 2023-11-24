using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    // To Do private IWeaponService _weaponService;

    private void OnEnable() => 
        SubscribeShootButtonCallback();

    private void OnDisable() => 
        UnsubscribeShootButtonCallback();

    private void Shoot()
    {
        // To Do current IWeapon - Shoot
        //_weaponService.CurrentWeapon.Shoot();
        Debug.Log("Shoot!");
    }

    private void SelectPreviousWeapon()
    {
        // To Do current IWeapon - _weaponService.SelectWeapon();
        //_weaponService.SelectPreviousWeapon();
        Debug.Log("SelectPreviousWeapon!");
    }

    private void SelectNextWeapon()
    {
        // To Do current IWeapon - Shoot
        //_weaponService.SelectNextWeapon();
        Debug.Log("SelectNextWeapon!");
    }

    private void SubscribeShootButtonCallback()
    {
        try
        {
            _playerInput.OnShootButtonDown += Shoot;

            _playerInput.OnPreviousWeaponSelect += SelectPreviousWeapon;
            _playerInput.OnNextWeaponSelect += SelectNextWeapon;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    private void UnsubscribeShootButtonCallback()
    {
        try
        {
            _playerInput.OnShootButtonDown -= Shoot;

            _playerInput.OnPreviousWeaponSelect -= SelectPreviousWeapon;
            _playerInput.OnNextWeaponSelect -= SelectNextWeapon;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
