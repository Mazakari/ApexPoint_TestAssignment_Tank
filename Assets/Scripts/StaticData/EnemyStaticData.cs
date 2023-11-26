using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStaticData", menuName = "StaticData/Enemy")]
public class EnemyStaticData : ScriptableObject
{
    [Header("Type")]
    public EnemyType type;

    [Space(10)]
    [Header("Survival Stats")]
    public float health;

    [Range(0.1f, 1f)]
    public float armor;

    [Space(10)]
    [Header("Speed Stats")]
    public float moveSpeed;
}
