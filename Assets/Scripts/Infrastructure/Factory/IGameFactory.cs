using UnityEngine;

public interface IGameFactory : IService
{
    GameObject CreatePlayer(Vector3 at);
    GameObject CreateEnemy(Transform parent);
    GameObject CreateLevelHud();
    PlayerTankStaticData[] GetPlayerTanksStaticData();
    EnemyStaticData[] GetEnemyStaticData();
    ObjectPoolStaticData GetPoolStaticData();
}
