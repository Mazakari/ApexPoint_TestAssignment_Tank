public interface IStaticDataService : IService
{
    EnemyStaticData GetEnemyData(EnemyType type);
    PlayerTankStaticData GetTankData(PlayerTankType type);
}
