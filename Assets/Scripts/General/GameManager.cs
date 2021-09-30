using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameObject Destination { get; private set; }
    public GameObject Canon { get; private set; }
    public GameObject Platform { get; private set; }
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    private Action LeftButtonClick;
    private Action GameStart;
    private int score = 0;

    [SerializeField] EnemySpawnData enemySpawnData;
    [SerializeField] TextMeshProUGUI tapToPlayText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject backgroundImage;
    [SerializeField] GameObject gameoverText;

    [Header("Debug Values")]
    [SerializeField] bool isGameStarted;
    [SerializeField] bool canInstantiateEnemyWave;
    [SerializeField] bool isGameOver;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        LeftButtonClick = Canon.GetComponent<CanonController>().SpawnPlayer;
        GameStart = OnGameStart;
    }

    private void Update()
    {
        if (!IsGameOver)
        {
            HandleInput();
        }
        else
        {
            StartCoroutine(FadeOutScreen());
        }
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
            tapToPlayText.gameObject.SetActive(false);
            GameStart?.Invoke();
        }
    }

    private void OnGameStart()
    {
        StartCoroutine(GameStartRoutine(1.5f));
    }

    public void FindInstances()
    {
        Platform = GameObject.Find("Platform");
        Destination = GameObject.Find("Destination");
        Canon = GameObject.Find("Canon");
    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "Score: " + score.ToString();
    }

    public IEnumerator FadeOutScreen()
    {
        Image image = backgroundImage.GetComponent<Image>();
        Color tempColor = image.color;
        while (tempColor.a <= 1)
        {
            tempColor.a += .01f;
            image.color = tempColor;
            yield return null;
        }
        gameoverText.SetActive(true);
        isGameOver = true;
    }

    private IEnumerator SpawnEnemyWaveRoutine(float waitTime)
    {
        canInstantiateEnemyWave = false;
        float randPosX, ranPosZ;
        for (int i = 0; i < enemySpawnData.EnemyWaveCount; i++)
        {
            randPosX = Random.Range(-enemySpawnData.EnemySpawnPosXThreshold, enemySpawnData.EnemySpawnPosXThreshold);
            ranPosZ = Random.Range(enemySpawnData.EnemySpawnPosZThreshold, enemySpawnData.EnemySpawnPosZThreshold + .5f);
            var enemyStartPos = new Vector3(Destination.transform.position.x + randPosX, 0f, Destination.transform.position.z - ranPosZ);
            var enemyQuaternion = Quaternion.Euler(0f, 180f, 0f);
            GameObject enemy = Random.Range(0, 100 / enemySpawnData.HugeEnemySpawnPercentRate) == 0
                ? PoolManager.Instance.Get(PoolGameObjectType.HugeEnemy)
                : PoolManager.Instance.Get(PoolGameObjectType.Enemy);
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
