using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    [Header("Rotation Settings")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 10f;
    private float _inputYRotation = 0;

    private void Update() =>
        ReadInputVector();

    private void FixedUpdate() =>
        Move();

    private void Move() =>
        Rotate();

    private void ReadInputVector()
    {
        try
        {
            _inputYRotation = _playerInput.GetRotationYInput();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void Rotate()
    {
        try
        {
            _rigidbody.transform.eulerAngles = new(
                _rigidbody.transform.eulerAngles.x, 
                _rigidbody.transform.eulerAngles.y + _inputYRotation * _speed * Time.fixedDeltaTime, 
                _rigidbody.transform.eulerAngles.z);
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
}
