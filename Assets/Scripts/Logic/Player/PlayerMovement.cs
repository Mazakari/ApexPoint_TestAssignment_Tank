using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    [Header("Move Settings")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 10f;
    private Vector3 _inputVector = Vector3.zero;

    private void Update() => 
        ReadInputVector();

    private void FixedUpdate() =>
        Move();

    private void Move() =>
        AddVelocity();

    private void ReadInputVector()
    {
        try
        {
            _inputVector = _playerInput.GetMovementInput();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    private void AddVelocity()
    {
        try
        {
            _rigidbody.velocity = _inputVector.z * _speed * Time.fixedDeltaTime * transform.forward;
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
}
