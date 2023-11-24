using UnityEngine;

public class LoadLevelState : IPayloadedState<string>
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;

    public LoadLevelState(
        GameStateMachine gameStateMachine, 
        SceneLoader sceneLoader, 
        LoadingCurtain curtain, 
        IGameFactory gameFactory)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        _gameFactory = gameFactory;
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
        InitServices();
        InitGameWorld();
        EnterGameLoopState();
    }

    private void InitServices()
    {
    }

    private void InitGameWorld()
    {
        // To Do change to weapon set
        //GameObject currentSkinPrefab = _progressService.Progress.gameData.currentSkinPrefab;
        InitPlayer();
        CreateLevelHud();
    }

    private GameObject GetPlayerSpawnPointReference() =>
        GameObject.FindGameObjectWithTag(Constants.PLAYER_SPAWN_POINT_TAG);

    private void InitPlayer()
    {
        try
        {
            GameObject spawnPos = GetPlayerSpawnPointReference();
            GameObject player = SpawnPlayerAtPosition(spawnPos.transform.position);
            InitPlayerRespawnPosition(spawnPos, player);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

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

    private void EnterGameLoopState() =>
       _gameStateMachine.Enter<GameLoopState>();

    private GameObject SpawnPlayerAtPosition(Vector3 position) =>
       _gameFactory.CreatePlayer(position);


    private void InitPlayerRespawnPosition(GameObject spawnPos, GameObject player)
    {
        if (player.TryGetComponent(out PlayerRespawn respawn))
        {
            respawn.SetRespawnPointReferrence(spawnPos.transform);
        }
    }
}