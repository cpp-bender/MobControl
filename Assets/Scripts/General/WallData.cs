using UnityEngine;

[CreateAssetMenu(fileName = "Wall Data", menuName = "Mob Control/Wall Data")]
public class WallData : ScriptableObject
{
    [SerializeField] float moveBetween;
    [SerializeField] float moveBetweenSpeed;

    public float MoveBetween { get => moveBetween; }
    public float MoveBetweenSpeed { get => moveBetweenSpeed; }
}
