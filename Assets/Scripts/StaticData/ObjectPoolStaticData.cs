using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPoolStaticData", menuName = "StaticData/ObjectPool")]
public class ObjectPoolStaticData : ScriptableObject
{
    public int enemyPoolSize = 20;
    public bool randomizeEnemyTypes = false;
}
