using UnityEngine;

[CreateAssetMenu(fileName = "Canon Controller Data", menuName = "Mob Control/Canon Controller Data")]
public class CanonControllerData : ScriptableObject
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject hugePlayerPrefab;
    [SerializeField] float moveSpeed;
    [SerializeField] float moveThreshold;
    [SerializeField] float pushRoutineFrameCount;
    [Range(0f, 5f)] [SerializeField] float playerRespawnTime;
    [Range(0, 100)] [SerializeField] int hugePlayerSpawnPercentRate;
    [Tooltip("In br.")] [SerializeField] float pushTo;

    public GameObject PlayerPrefab { get => playerPrefab; }
    public float MoveSpeed { get => moveSpeed; }
    public float MoveThreshold { get => moveThreshold; }
    public float PushTo { get => pushTo; }
    public float PushRoutineFrameCount { get => pushRoutineFrameCount; }
    public int HugePlayerSpawnPercentRate { get => hugePlayerSpawnPercentRate; }
    public float PlayerRespawnTime { get => playerRespawnTime; }
}
