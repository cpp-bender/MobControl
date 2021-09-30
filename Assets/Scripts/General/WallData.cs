using UnityEngine;

[CreateAssetMenu(fileName = "Wall Data", menuName = "Mob Control/Wall Data")]
public class WallData : ScriptableObject
{
    [SerializeField] float moveBetweenSpeed;

    public float MoveBetweenSpeed { get => moveBetweenSpeed; }
}
