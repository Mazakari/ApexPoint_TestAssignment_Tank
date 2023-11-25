using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private Rigidbody _rigidbody;
    private float _speed = 10f;
    private float _inputYRotation = 0;

    private void Update() =>
        ReadInputVector();

    private void FixedUpdate() =>
        Rotation();

    private void Rotation() =>
        Rotate();

    public void SetRotationSpeed(float speed) => 
        _speed = speed;

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
            if (_inputYRotation == 0)
            {
                return;
            }

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
