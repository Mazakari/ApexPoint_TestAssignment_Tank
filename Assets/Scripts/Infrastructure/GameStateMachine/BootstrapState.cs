using UnityEngine;

public class BootstrapState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _services = services;

        RegisterServices();
    }

    public void Enter()
    {
        SetFpsTarget();
        InitSceneLoader();

        Debug.Log("BootstrapState");
        _sceneLoader.Load(Constants.INITIAL_SCENE_NAME, onLoaded: EnterLoadMainMenu);
    }
    public void Exit() { }

    private void InitSceneLoader() => 
        _sceneLoader.GetBuildNamesFromBuildSettings();

    private void EnterLoadMainMenu() =>
        _gameStateMachine.Enter<LoadLevelState, string>(Constants.FIRST_LEVEL_NAME);

    private void RegisterServices()
    {
        _services.RegisterSingle<IInputService>(new InputService());
        _services.RegisterSingle<IAssets>(new AssetProvider());
        _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
        _services.RegisterSingle<IStaticDataService>(new StaticDataService(_services.Single<IGameFactory>()));
        _services.RegisterSingle<IEnemyService>(new EnemyService());
        _services.RegisterSingle<IPoolService>(new PoolService(
            _services.Single<IGameFactory>(), 
            _services.Single<IStaticDataService>(), 
            _services.Single<IEnemyService>()));
    }

    // System Settings
    private void SetFpsTarget() =>
        Application.targetFrameRate = 120;
}
