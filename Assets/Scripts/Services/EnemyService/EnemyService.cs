using UnityEngine;

public class EnemyService : IEnemyService
{
    public Transform Player {  get; private set; }
    public int MaxOnScreenEnemies { get; private set; }
   
    public EnemyService()
    {
        //ToDo rework to get from LevelSettingsStaticData
        MaxOnScreenEnemies = Constants.MAX_ENEMIES_ON_SCREEN;
    }

    public void SetPlayerTransform(Transform player) => 
        Player = player;

   
}