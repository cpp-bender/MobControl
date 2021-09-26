using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Mob Crowd/Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] float moveSpeed;

    public float MoveSpeed { get => moveSpeed; }
}
