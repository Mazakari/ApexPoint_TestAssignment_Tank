using UnityEngine;

[CreateAssetMenu(fileName ="PlayerTankStaticData", menuName ="StaticData/PlayerTank")]
public class PlayerTankStaticData : ScriptableObject
{
    [Header("Type")]
    public PlayerTankType type;

    [Space(10)]
    [Header("Survival Stats")]
    public float health;

    [Range(0.1f,1f)]
    public float armor;

    [Space(10)]
    [Header("Speed Stats")]
    public float moveSpeed;
    public float rotateSpeed;
}
