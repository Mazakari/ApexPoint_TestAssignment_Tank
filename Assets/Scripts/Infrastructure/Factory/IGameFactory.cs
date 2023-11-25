using UnityEngine;

public interface IGameFactory : IService
{
    GameObject CreatePlayer(Vector3 at);
    GameObject CreateLevelHud();
    PlayerTankStaticData[] GetPlayerTanksStaticData();
}
