using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameObject Destination { get; private set; }
    public GameObject Canon { get; private set; }
    public Action LeftButtonClick;
    public Action GameStart;

    [SerializeField] EnemySpawnData enemySpawnData;

    [Header("Debug Values")]
    [SerializeField] bool isGameStarted;
    [SerializeField] bool canInstantiateEnemyWave;

    protected override void Awake()
    {
        base.Awake();
        Destination = GameObject.Find("Destination");
        Canon = GameObject.Find("Canon");
    }

    private void OnEnable()
    {
        LeftButtonClick = Canon.GetComponent<CanonController>().SpawnPlayer;
        GameStart = OnGameStart;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (canInstantiateEnemyWave)
        {
            StartCoroutine(SpawnEnemyWaveRoutine(enemySpawnData.EnemyWaveSpawnRate));
        }

        if (Input.GetMouseButtonDown(0))
        {
            LeftButtonClick?.Invoke();
        }

        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            GameStart?.Invoke();
        }
    }

    private void OnGameStart()
    {
        StartCoroutine(GameStartRoutine(1.5f));
    }

    private IEnumerator SpawnEnemyWaveRoutine(float waitTime)
    {
        canInstantiateEnemyWave = false;
        float randPosX, ranPosY;
        for (int i = 0; i < enemySpawnData.EnemyWaveCount; i++)
        {
            randPosX = Random.Range(-enemySpawnData.EnemySpawnPosXThreshold, enemySpawnData.EnemySpawnPosXThreshold);
            ranPosY = Random.Range(enemySpawnData.EnemySpawnPosYThreshold, enemySpawnData.EnemySpawnPosYThreshold + .5f);
            var enemyStartPos = new Vector3(Destination.transform.position.x + randPosX, 0f, Destination.transform.position.z - ranPosY);
            var enemyQuaternion = Quaternion.Euler(0f, 180f, 0f);
            GameObject enemy = PoolManager.Instance.Get(PoolGameObjectType.Enemy);
            enemy.transform.position = enemyStartPos;
            enemy.transform.rotation = enemyQuaternion;
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSecondsRealtime(waitTime);
        canInstantiateEnemyWave = true;
    }

    private IEnumerator GameStartRoutine(float waitTime)
    {
        isGameStarted = true;
        yield return new WaitForSecondsRealtime(waitTime);
        canInstantiateEnemyWave = true;
    }
}
