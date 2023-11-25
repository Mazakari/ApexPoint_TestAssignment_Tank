using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private Rigidbody _rigidbody;

    private float _speed = 10f;
    private Vector3 _inputVector = Vector3.zero;

    private void Update() => 
        ReadInputVector();

    private void FixedUpdate() =>
        Move();

    public void SetMovementSpeed(float speed) => 
        _speed = speed;

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
            if (_inputVector.z == 0)
            {
                return;
            }

            _rigidbody.velocity = _inputVector.z * _speed * Time.fixedDeltaTime * transform.forward;
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
}
