public interface IStaticDataService : IService
{
    PlayerTankStaticData GetTankData(PlayerTankType type);
}
