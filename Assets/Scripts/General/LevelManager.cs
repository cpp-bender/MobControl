using UnityEngine;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    [SerializeField] LevelData[] levels;

    private int currentLevelIndex = 0;

    protected override void Awake()
    {
        base.Awake();
        InitializeCurrentLevel();
        GameManager.Instance.FindInstances();
    }

    private void InitializeCurrentLevel()
    {
        LevelData currentLevel = levels[currentLevelIndex];

        InitPlatform(currentLevel);

        InitDestination(currentLevel);

        InitCanon(currentLevel);

        InitWalls(currentLevel);

        InitObstacles(currentLevel);
    }

    private void InitObstacles(LevelData currentLevel)
    {
        for (int i = 0; i < currentLevel.ObstacleCount; i++)
        {
            float maxDistanceZ = currentLevel.PathScaleZ * 10 - 30f;
            float minDistanceZ = currentLevel.ObstacleMinDistanceZ;
            float maxDistanceX = currentLevel.PathScaleX * 6;
            float randomPosX = Random.Range(-maxDistanceX, maxDistanceX);
            float randomPosZ = Random.Range(minDistanceZ, maxDistanceZ);
            Vector3 obstaclePos = new Vector3(randomPosX, currentLevel.ObstaclePrefab.transform.position.y, randomPosZ);
            Quaternion obstacleEuler = Quaternion.Euler(0f, 45f, 0f);
            GameObject obstacle = Instantiate(currentLevel.ObstaclePrefab, obstaclePos, obstacleEuler, transform);
            obstacle.name = $"Obstacle {(i + 1)}";
        }
    }

    private void InitWalls(LevelData currentLevel)
    {
        for (int i = 0; i < currentLevel.WallCount; i++)
        {
            float maxDistanceZ = currentLevel.PathScaleZ * 10 - 30f;
            float minDistanceZ = currentLevel.WallMinDistanceZ;
            float maxDistanceX = currentLevel.PathScaleX * 6;
            float randomPosX = Random.Range(-maxDistanceX, maxDistanceX);
            float randomPosZ = Random.Range(minDistanceZ, maxDistanceZ);
            Vector3 wallPos = new Vector3(randomPosX, currentLevel.WallPrefab.transform.position.y, randomPosZ);
            GameObject wall = Instantiate(currentLevel.WallPrefab, wallPos, Quaternion.identity, transform);
            wall.name = $"Wall {i + 1}";
        }
    }

    private void InitCanon(LevelData currentLevel)
    {
        GameObject canon = Instantiate(currentLevel.CanonPrefab, transform);
        canon.name = "Canon";
    }

    private void InitDestination(LevelData currentLevel)
    {
        GameObject destination = Instantiate(currentLevel.DestinationPrefab, transform);
        destination.name = "Destination";
        destination.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, currentLevel.PathScaleZ * 9f);
    }

    private void InitPlatform(LevelData currentLevel)
    {
        GameObject platform = Instantiate(currentLevel.PlatformPrefab, transform);
        platform.name = "Platform";
        platform.transform.localScale = new Vector3(currentLevel.PathScaleX, currentLevel.PathScaleY, currentLevel.PathScaleZ);
    }
}
