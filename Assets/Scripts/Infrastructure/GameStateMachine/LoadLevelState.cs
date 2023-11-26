using System;
using UnityEngine;

public class LoadLevelState : IPayloadedState<string>
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    private readonly IStaticDataService _staticData;
    private readonly IEnemyService _enemyService;
    private readonly IPoolService _poolService;

    public LoadLevelState(
        GameStateMachine gameStateMachine, 
        SceneLoader sceneLoader, 
        LoadingCurtain curtain, 
        IGameFactory gameFactory,
        IStaticDataService staticDataService,
        IEnemyService enemyService,
        IPoolService poolService)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        _gameFactory = gameFactory;
        _staticData = staticDataService;
        _enemyService = enemyService;
        _poolService = poolService;
    }

    public void Enter(string sceneName)
    {
        Debug.Log("LoadLevelState");
        _curtain.Show();
        _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit() => 
        _curtain.Hide();

    private void OnLoaded()
    {
        CreateLevelHud();
        InitGameWorld();
        InitServices();
        
        SpawnFirstEnemies();

        EnterGameLoopState();
    }


    private void InitGameWorld() => 
        InitPlayer();

    private void SpawnFirstEnemies()
    {
        EnemySpawner spawner = GameObject.FindAnyObjectByType<EnemySpawner>();
        spawner.FirstEnemySpawn();
    }

    private GameObject GetPlayerSpawnPointReference() =>
        GameObject.FindGameObjectWithTag(Constants.PLAYER_SPAWN_POINT_TAG);

    private void InitPlayer()
    {
        try
        {
            GameObject spawnPos = GetPlayerSpawnPointReference();
            GameObject player = SpawnPlayerAtPosition(spawnPos.transform.position);
            InitPlayerTank(spawnPos, player);

            InitEnemyService(player);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void InitEnemyService(GameObject player) => 
        _enemyService.SetPlayerTransform(player.transform);

    private void CreateLevelHud()
    {
        try
        {
            _gameFactory.CreateLevelHud();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    private void InitServices() =>
       InitPoolService();
    private void InitPoolService()
    {
        try
        {
            _poolService.InitEnemyPool();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void EnterGameLoopState() =>
       _gameStateMachine.Enter<GameLoopState>();

    private GameObject SpawnPlayerAtPosition(Vector3 position) =>
       _gameFactory.CreatePlayer(position);

    private void InitPlayerTank(GameObject spawnPos, GameObject player)
    {
        if (player.TryGetComponent(out PlayerTankConstructor constructor))
        {
            constructor.Construct(spawnPos.transform, _staticData);
        }
    }
}