using UnityEngine;

public interface IAssets : IService
{
    EnemyStaticData[] GetEnemyStaticData();
    PlayerTankStaticData[] GetPlayerTanksStaticData();
    ObjectPoolStaticData GetPoolStaticData();
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 at);
    GameObject Instantiate(string path, Transform parent);
}