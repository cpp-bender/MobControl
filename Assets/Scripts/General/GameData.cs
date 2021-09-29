using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Mob Control/Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject playerPrefab;

    public GameObject EnemyPrefab { get => enemyPrefab; }
}
