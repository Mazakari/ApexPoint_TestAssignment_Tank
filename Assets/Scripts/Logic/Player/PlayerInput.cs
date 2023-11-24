using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private IInputService _inputService;

    public event Action OnShootButtonDown;
    public event Action OnPreviousWeaponSelect;
    public event Action OnNextWeaponSelect;

    private void OnEnable()
    {
        GetServiceReference();
        SubscribeShootButtonInputCallback();
    }

    private void OnDisable() => 
        UnubscribeShootButtonInputCallback();

    private void GetServiceReference() => 
        _inputService = AllServices.Container.Single<IInputService>();

    public Vector3 GetMovementInput()
    {
        Vector3 input = _inputService.InputActions.Player.Move.ReadValue<Vector3>();
        Vector3 convertedYtoZ = new(input.x,input.z, input.y);
        return convertedYtoZ;
    }

    public float GetRotationYInput()
    {
        Vector3 input = _inputService.InputActions.Player.Rotate.ReadValue<Vector3>();
        float yRotation = input.x;
        return yRotation;
    }


    private void SubscribeShootButtonInputCallback()
    {
        try
        {
            _inputService.InputActions.Player.Shoot.performed += ShootButtonDown;

            _inputService.InputActions.Player.PreviousWeapon.performed += PreviousWeaponSelect;
            _inputService.InputActions.Player.NextWeapon.performed += NextWeaponSelect;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    private void UnubscribeShootButtonInputCallback()
    {
        try
        {
            _inputService.InputActions.Player.Shoot.performed -= ShootButtonDown;

            _inputService.InputActions.Player.PreviousWeapon.performed -= PreviousWeaponSelect;
            _inputService.InputActions.Player.NextWeapon.performed -= NextWeaponSelect;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void ShootButtonDown(InputAction.CallbackContext context) =>
       OnShootButtonDown?.Invoke();

    private void PreviousWeaponSelect(InputAction.CallbackContext context) => 
        OnPreviousWeaponSelect?.Invoke();
    private void NextWeaponSelect(InputAction.CallbackContext context) => 
        OnNextWeaponSelect?.Invoke();

}
