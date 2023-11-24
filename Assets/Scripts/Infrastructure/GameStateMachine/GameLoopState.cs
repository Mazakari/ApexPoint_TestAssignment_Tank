using UnityEngine;

public class GameLoopState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;

    public GameLoopState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
        Debug.Log("GameLoopState");
    }
    public void Exit()
    {
    }

    private void RestartLevel() =>
        _gameStateMachine.Enter<LoadLevelState, string>(Constants.FIRST_LEVEL_NAME);
}
