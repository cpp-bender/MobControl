using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Spawn Data", menuName = "Mob Control/Enemy Spawn Data")]
public class EnemySpawnData : ScriptableObject
{
    [SerializeField] int enemyWaveCount;
    [SerializeField] float enemyWaveSpawnRate;
    [SerializeField] float enemySpawnPosXThreshold;
    [SerializeField] float enemySpawnPosZThreshold;
    [Range(0, 100)] [SerializeField] int hugeEnemySpawnPercentRate;

    public int EnemyWaveCount { get => enemyWaveCount; }
    public float EnemyWaveSpawnRate { get => enemyWaveSpawnRate; }
    public float EnemySpawnPosXThreshold { get => enemySpawnPosXThreshold; }
    public float EnemySpawnPosZThreshold { get => enemySpawnPosZThreshold; }
    public int HugeEnemySpawnPercentRate { get => hugeEnemySpawnPercentRate; }
}
