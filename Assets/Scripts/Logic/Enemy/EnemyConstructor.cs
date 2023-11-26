using UnityEngine;

public class EnemyConstructor : MonoBehaviour
{
    [SerializeField] private MoveToPlayer _moveToPlayer;
    [SerializeField] private EnemyHealth _enemyHealth;

    public void Construct(EnemyStaticData data, IEnemyService enemyService)
    {
        try
        {
            InitMoveToPlayer(enemyService, data);
            _enemyHealth.SetHealthAndArmor(data);
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }

    private void InitMoveToPlayer(IEnemyService enemyService, EnemyStaticData enemyData)
    {
        _moveToPlayer.SetMovementSpeed(enemyData.moveSpeed);
        _moveToPlayer.SetEnemyServiceReference(enemyService);
    }
}
