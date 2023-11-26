using UnityEngine;

public class EnemyConstructor : MonoBehaviour
{
    [SerializeField] private MoveToPlayer _moveToPlayer;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private DamagePlayer _damagePlayer;

    private EnemyStaticData _data;

    private void OnDisable() => 
        ResetHealth();

    public void Construct(EnemyStaticData data, IEnemyService enemyService)
    {
        try
        {
            _data = data;

            InitMoveToPlayer(enemyService, _data);
            ResetHealth();
            SetEnemyDamage(data);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void ResetHealth() => 
        _enemyHealth.SetHealthAndArmor(_data);

    private void InitMoveToPlayer(IEnemyService enemyService, EnemyStaticData enemyData)
    {
        _moveToPlayer.SetMovementSpeed(enemyData.moveSpeed);
        _moveToPlayer.SetEnemyServiceReference(enemyService);
    }
    private void SetEnemyDamage(EnemyStaticData data) =>
       _damagePlayer.SetDamage(data.damage);
}
