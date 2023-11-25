public class StaticDataService : IStaticDataService
{
    public PlayerTankStaticData[] PlayerTanksData { get; private set; }

    private readonly IGameFactory _gameFactory;

    public StaticDataService(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;

        GetPlayerStaticData();
    }

    public PlayerTankStaticData GetTankData(PlayerTankType type)
    {
        PlayerTankStaticData data = null;

        for (int i = 0; i < PlayerTanksData.Length; i++)
        {
            if (PlayerTanksData[i].type == type)
            {
                data = PlayerTanksData[i];
                break;
            }
        }

        return data;
    }

    private void GetPlayerStaticData() => 
        PlayerTanksData = _gameFactory.GetPlayerTanksStaticData();
}