using UnityEngine;

public interface IEnemyService : IService
{
    Transform Player { get; }
    int MaxOnScreenEnemies { get; }

    void SetPlayerTransform(Transform player);
}