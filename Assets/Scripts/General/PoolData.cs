using UnityEngine;

[CreateAssetMenu(fileName = "Pool Data", menuName = "Mob Control/Pool Data")]
public class PoolData : ScriptableObject
{
    [SerializeField] GameObject[] prefabs;

    public GameObject[] Prefabs { get => prefabs; }
}
