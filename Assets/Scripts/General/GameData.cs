using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Mob Control/Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;

    public GameObject EnemyPrefab { get => enemyPrefab; }
}
