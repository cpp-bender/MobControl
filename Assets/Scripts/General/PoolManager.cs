using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonMonoBehaviour<PoolManager>
{
    [SerializeField] PoolData poolData;

    private Queue<GameObject>[] poolObjects;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        poolObjects = new Queue<GameObject>[poolData.Prefabs.Length];
        for (int i = 0; i < poolData.Prefabs.Length; i++)
        {
            poolObjects[i] = new Queue<GameObject>();
            GameObject go = new GameObject(poolData.Prefabs[i].name);
            go.transform.SetParent(transform);
        }
    }

    public GameObject Get(PoolGameObjectType poolGameObject)
    {
        int index = (int)poolGameObject;
        if (poolObjects[index].Count == 0)
        {
            AddToPool(poolData.Prefabs[index], index);
        }
        var poolObject = poolObjects[index].Dequeue();
        poolObject.SetActive(true);
        return poolObject;
    }

    private void AddToPool(GameObject gameObject, int gameObjectIndex)
    {
        var pooledObject = Instantiate(gameObject, transform.GetChild(gameObjectIndex));
        poolObjects[gameObjectIndex].Enqueue(pooledObject);
    }

    public void ReturnToPool(GameObject objectToBePooled, PoolGameObjectType poolGameObject)
    {
        int index = (int)poolGameObject;
        objectToBePooled.SetActive(false);
        poolObjects[index].Enqueue(objectToBePooled);
    }
}

public enum PoolGameObjectType
{
    Player = 0,
    Enemy = 1,
    HugePlayer = 2,
    HugeEnemy = 3,
};
