using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private float _speed = 10f;
    private float _stopDistance = 0.001f;
    private Vector3 _currentPosition = Vector3.zero;

    private IEnemyService _enemyService;

    public void SetEnemyServiceReference(IEnemyService enemyService) => 
        _enemyService = enemyService;

    public void SetMovementSpeed(float speed) =>
       _speed = speed;

    private void Update() => 
        LookAtPlayer();

    private void FixedUpdate() => 
        MoveTowardsPlayer();

    private void LookAtPlayer()
    {
        try
        {
            transform.LookAt(_enemyService.Player);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void MoveTowardsPlayer()
    {
        try
        {
            _currentPosition = transform.position;

            float distance = Vector3.Distance(_currentPosition, _enemyService.Player.position);

            if (distance > _stopDistance)
            {
                Vector3 targetDirection = _enemyService.Player.position - _currentPosition;
                _rigidbody.velocity = _speed * Time.fixedDeltaTime * targetDirection;
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
