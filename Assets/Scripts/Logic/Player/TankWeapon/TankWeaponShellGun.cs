using UnityEngine;

public class TankWeaponShellGun : MonoBehaviour, ITankWeapon
{
    public void Shoot()
    {
        Debug.Log("Shell shoot");
    }
}
