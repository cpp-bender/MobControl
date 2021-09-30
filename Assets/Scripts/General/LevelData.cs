using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "Mob Control/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Path Parameters")]
    [SerializeField] GameObject platformPrefab;
    [SerializeField] float pathScaleX;
    [SerializeField] float pathScaleY;
    [SerializeField] float pathScaleZ;

    [Header("Destination Parameters")]
    [SerializeField] GameObject destinationPrefab;

    [Header("Canon Parameters")]
    [SerializeField] GameObject canonPrefab;

    [Header("Wall Parameters")]
    [SerializeField] GameObject wallPrefab;
    [SerializeField] int wallCount;
    [SerializeField] float wallMinDistanceZ;

    [Header("Obstacle Parameters")]
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] int obstacleCount;
    [SerializeField] float obstacleMinDistanceZ;

    public GameObject PlatformPrefab { get => platformPrefab; }
    public float PathScaleX { get => pathScaleX; }
    public float PathScaleZ { get => pathScaleZ; }
    public float PathScaleY { get => pathScaleY; }
    public GameObject DestinationPrefab { get => destinationPrefab; }
    public GameObject CanonPrefab { get => canonPrefab; }
    public GameObject WallPrefab { get => wallPrefab; }
    public int WallCount { get => wallCount; }
    public GameObject ObstaclePrefab { get => obstaclePrefab; }
    public int ObstacleCount { get => obstacleCount; }
    public float WallMinDistanceZ { get => wallMinDistanceZ; }
    public float ObstacleMinDistanceZ { get => obstacleMinDistanceZ; }
}
