using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Spawn Data", menuName = "Mob Control/Enemy Spawn Data")]
public class EnemySpawnData : ScriptableObject
{
    [SerializeField] int enemyWaveCount;
    [SerializeField] float enemyWaveSpawnRate;
    [SerializeField] float enemySpawnPosXThreshold;
    [SerializeField] float enemySpawnPosYThreshold;

    public int EnemyWaveCount { get => enemyWaveCount; }
    public float EnemyWaveSpawnRate { get => enemyWaveSpawnRate; }
    public float EnemySpawnPosXThreshold { get => enemySpawnPosXThreshold; }
    public float EnemySpawnPosYThreshold { get => enemySpawnPosYThreshold; }
}
