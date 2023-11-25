using UnityEngine;

public class GameFactory : IGameFactory
{
    private readonly IAssets _assets;

    public GameFactory(IAssets assets) =>
        _assets = assets;

    #region PLAYER
    public GameObject CreatePlayer(Vector3 at) =>
        InstantiateAtPosition(AssetPath.PLAYER_PREFAB_PATH, at);

    public PlayerTankStaticData[] GetPlayerTanksStaticData() =>
        _assets.GetPlayerTanksStaticData();
    #endregion

    #region HUDS
    public GameObject CreateLevelHud() =>
       InstantiatePrefab(AssetPath.LEVEL_CANVAS_PATH);
    #endregion

    #region INSTANTIATE
    private GameObject InstantiateInParent(string prefabPath, Transform parent)
    {
        GameObject obj = _assets.Instantiate(prefabPath, parent);
        return obj;
    }

    private GameObject InstantiatePrefab(string prefabPath)
    {
        GameObject obj = _assets.Instantiate(prefabPath);
        return obj;
    }

    private GameObject InstantiateAtPosition(string prefabPath, Vector3 at)
    {
        GameObject obj = _assets.Instantiate(prefabPath, at);
        return obj;
    }
    #endregion
}
