using UnityEngine;

public interface IAssets : IService
{
    PlayerTankStaticData[] GetPlayerTanksStaticData();
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 at);
    GameObject Instantiate(string path, Transform parent);
}