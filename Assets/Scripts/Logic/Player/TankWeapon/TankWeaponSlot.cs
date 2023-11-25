using UnityEngine;

public class TankWeaponSlot : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;

    private int _currentWeaponIndex = 0;

    private ITankWeapon _currentWeapon;

    private void OnEnable() => 
        InitWeapons();

    public void SelectNextWeapon()
    {
        DectivateWeapon(_currentWeaponIndex);
        IncrementCurrentWeaponIndex();
        ActivateWeapon(_currentWeaponIndex);
        SetCurrentWeaponReference();
    }
    public void SelectPreviousWeapon()
    {
        DectivateWeapon(_currentWeaponIndex);
        DecrementCurrentWeaponIndex();
        ActivateWeapon(_currentWeaponIndex);
        SetCurrentWeaponReference();
    }

    public void ShootCurrentWeapon()
    {
        try
        {
            _currentWeapon.Shoot();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void IncrementCurrentWeaponIndex()
    {
        _currentWeaponIndex++;
        if (_currentWeaponIndex >= _weapons.Length)
        {
            ResetCurrentWeaponIndex();
        }
    }
    private void DecrementCurrentWeaponIndex()
    {
        _currentWeaponIndex--;
        if (_currentWeaponIndex < 0)
        {
            SetIndexToLastWeaponElement();
        }
    }

    private void SetIndexToLastWeaponElement() => 
        _currentWeaponIndex = _weapons.Length - 1;

    private void ResetCurrentWeaponIndex() => 
        _currentWeaponIndex = 0;

    private void InitWeapons()
    {
        try
        {
            DeactivateAllWeapons();
            ActivateWeapon(_currentWeaponIndex);
            SetCurrentWeaponReference();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    private void ActivateWeapon(int weaponIndex) => 
        _weapons[weaponIndex].SetActive(true);

    private void DectivateWeapon(int weaponIndex) =>
       _weapons[weaponIndex].SetActive(false);

    private void DeactivateAllWeapons()
    {
        if (_weapons.Length > 0)
        {
            foreach (GameObject weapon in _weapons)
            {
                weapon.SetActive(false);
            }
        }
    }

    private void SetCurrentWeaponReference() =>
        _currentWeapon = _weapons[_currentWeaponIndex].GetComponent<ITankWeapon>();
}
