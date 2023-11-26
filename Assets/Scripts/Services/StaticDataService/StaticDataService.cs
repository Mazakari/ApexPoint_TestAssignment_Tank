public class StaticDataService : IStaticDataService
{
    private PlayerTankStaticData[] _playerTanksData;
    private EnemyStaticData[] _enemyData;

    private readonly IGameFactory _gameFactory;

    public StaticDataService(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;

        GetPlayerStaticData();
        GetEnemyStaticData();
    }

    public PlayerTankStaticData GetTankData(PlayerTankType type)
    {
        PlayerTankStaticData data = null;

        for (int i = 0; i < _playerTanksData.Length; i++)
        {
            if (_playerTanksData[i].type == type)
            {
                data = _playerTanksData[i];
                break;
            }
        }

        return data;
    }
    public EnemyStaticData GetEnemyData(EnemyType type)
    {
        EnemyStaticData data = null;

        for (int i = 0; i < _enemyData.Length; i++)
        {
            if (_enemyData[i].type == type)
            {
                data = _enemyData[i];
                break;
            }
        }

        return data;
    }


    private void GetPlayerStaticData() =>
        _playerTanksData = _gameFactory.GetPlayerTanksStaticData();
    private void GetEnemyStaticData() =>
        _enemyData = _gameFactory.GetEnemyStaticData();
}
