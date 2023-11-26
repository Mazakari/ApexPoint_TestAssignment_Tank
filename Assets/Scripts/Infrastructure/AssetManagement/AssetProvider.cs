using UnityEngine;

public class AssetProvider : IAssets
{
    public GameObject Instantiate(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab);
    }

    public GameObject Instantiate(string path, Vector3 at)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, at, Quaternion.identity);
    }

    public GameObject Instantiate(string path, Transform parent)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, parent);
    }

    public PlayerTankStaticData[] GetPlayerTanksStaticData()
    {
        PlayerTankStaticData[] tanksData = Resources.LoadAll<PlayerTankStaticData>(AssetPath.PLAYER_TANKS_STATIC_DATA_PATH);
        return tanksData;
    }

    public EnemyStaticData[] GetEnemyStaticData()
    {
        EnemyStaticData[] enemyData = Resources.LoadAll<EnemyStaticData>(AssetPath.ENEMY_STATIC_DATA_PATH);
        return enemyData;
    }

    public ObjectPoolStaticData GetPoolStaticData()
    {
        ObjectPoolStaticData data = Resources.Load<ObjectPoolStaticData>(AssetPath.OBJECT_POOL_STATIC_DATA_PATH);
        return data;
    }
}