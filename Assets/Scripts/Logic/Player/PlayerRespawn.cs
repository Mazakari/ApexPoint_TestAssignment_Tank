using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform _playerRespawnPoint;

    public void SetRespawnPointReferrence(Transform respawnPoint) =>
     _playerRespawnPoint = respawnPoint;

    public void Respawn()
    {
        Debug.Log("Player respawned!");
    }
}
