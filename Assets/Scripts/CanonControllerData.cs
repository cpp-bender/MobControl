using UnityEngine;

[CreateAssetMenu(fileName = "Canon Controller Data", menuName = "Mob Crowd/Canon Controller Data")]
public class CanonControllerData : ScriptableObject
{
    [SerializeField] float moveSpeed;
    [SerializeField] float lowerThreshold;
    [SerializeField] float upperThreshold;

    public float MoveSpeed { get => moveSpeed; }
    public float LowerThreshold { get => lowerThreshold; }
    public float UpperThreshold { get => upperThreshold; }
}
