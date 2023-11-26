using UnityEngine;

public class EnemyService : IEnemyService
{
    public Transform Player {  get; private set; }
    public int MaxOnScreenEnemies { get; private set; }

    public EnemyService()
    {
        //ToDo rework to get from LevelSettingsStaticData
        MaxOnScreenEnemies = 10;
    }

    public void SetPlayerTransform(Transform player) => 
        Player = player;

}