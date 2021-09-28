using UnityEngine;

[CreateAssetMenu(fileName = "Canon Controller Data", menuName = "Mob Control/Canon Controller Data")]
public class CanonControllerData : ScriptableObject
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] float moveSpeed;
    [SerializeField] float moveThreshold;
    [SerializeField] float pushRoutineFrameCount;
    [Tooltip("In br.")] [SerializeField] float pushTo;

    public GameObject PlayerPrefab { get => playerPrefab; }
    public float MoveSpeed { get => moveSpeed; }
    public float MoveThreshold { get => moveThreshold; }
    public float PushTo { get => pushTo; }
    public float PushRoutineFrameCount { get => pushRoutineFrameCount; }
}
