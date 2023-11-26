using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [Space(10)]
    [Header("Collision Layers")]
    [SerializeField] private int _enemyLayer = 7;
    [SerializeField] private int _wallLayer = 6;


    private float _damage = 1f;
    private float _speed = 1f;

    private float _lifetime = 5f;
    private float _currentLifetime = 0;
    private bool _enabled = false;

    private void OnCollisionEnter(Collision collision)
    {
        HandleWallCollision(collision);
        HandleEnemyCollision(collision);
    }

    private void Update() => 
        LifetimeCouner();

    private void FixedUpdate() => 
        MoveProjectile();

    public void Construct(float damage, float speed)
    {
        _damage = damage;
        _speed = speed;
    }
    public void Launch() => 
        _enabled = true;
    private void HandleWallCollision(Collision collision)
    {
        if (collision.collider.gameObject.layer == _wallLayer)
        {
            Debug.Log("Wall hit");
            DisableProjectile();
        }
    }
    private void HandleEnemyCollision(Collision collision)
    {
        if (collision.collider.gameObject.layer == _enemyLayer)
        {
            Debug.Log("Enemy hit");
            IHealth enemyHealth = collision.collider.transform.parent.GetComponent<IHealth>();

            try
            {
                enemyHealth.GetDamage(_damage);
                DisableProjectile();
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
    private void LifetimeCouner()
    {
        if (_enabled)
        {
            if (_currentLifetime >= _lifetime)
            {
                _currentLifetime = 0;
                DisableProjectile();
            }

            _currentLifetime += Time.deltaTime;
        }
    }

    private void DisableProjectile()
    {
        _enabled = false;
        //ToDo rework to store projectile back to object pool
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void MoveProjectile()
    {
        try
        {
            if (_enabled)
            {
                _rigidbody.velocity = _speed * Time.fixedDeltaTime * transform.forward;
            }
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
}
