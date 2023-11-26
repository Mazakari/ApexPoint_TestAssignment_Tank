using UnityEngine;

public interface IPoolService : IService
{
    GameObject GetEnemy();
    void InitEnemyPool();
    void ReturnEnemy(GameObject enemy);
}
