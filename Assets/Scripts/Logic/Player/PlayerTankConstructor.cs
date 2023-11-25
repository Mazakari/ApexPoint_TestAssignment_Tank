using UnityEngine;

public class PlayerTankConstructor : MonoBehaviour
{
    [SerializeField] private PlayerTankType _playerTankType;

    [SerializeField] private PlayerRespawn _playerRespawn;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private PlayerHealth _playerHealth;

    public void Construct(Transform respawnPoint, IStaticDataService staticData)
    {
        try
        {
            PlayerTankStaticData tankData = staticData.GetTankData(_playerTankType);

            _playerRespawn.SetRespawnPointReferrence(respawnPoint);
            _playerMovement.SetMovementSpeed(tankData.moveSpeed);
            _playerRotation.SetRotationSpeed(tankData.rotateSpeed);
            _playerHealth.SetHealthAndArmor(tankData);
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
}
