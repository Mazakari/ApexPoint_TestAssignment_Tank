using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private TankWeaponSlot _slot;

    private void OnEnable() => 
        SubscribeShootButtonCallback();

    private void OnDisable() => 
        UnsubscribeShootButtonCallback();

    private void Shoot()
    {
        try
        {
            _slot.ShootCurrentWeapon();
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
        
    }

    private void SelectPreviousWeapon()
    {
        try
        {
            _slot.SelectPreviousWeapon();
            Debug.Log("SelectPreviousWeapon!");
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }

    private void SelectNextWeapon()
    {
        try
        {
            _slot.SelectNextWeapon();
            Debug.Log("SelectNextWeapon!");
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
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
