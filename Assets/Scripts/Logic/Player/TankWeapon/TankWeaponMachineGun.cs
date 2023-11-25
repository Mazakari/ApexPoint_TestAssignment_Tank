using UnityEngine;

public class TankWeaponMachineGun : MonoBehaviour, ITankWeapon
{
    public void Shoot()
    {
        Debug.Log("Machine gun shoot");
    }
}
