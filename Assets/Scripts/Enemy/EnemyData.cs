using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Mob Control/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] float moveSpeed;

    public float MoveSpeed { get => moveSpeed; }
}
