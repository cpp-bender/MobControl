using UnityEngine;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameObject Destination { get; private set; }
    public GameObject Canon { get; private set; }
    public GameObject enemyPrefab;
    public int enemyCount;
    public Action OnLeftButtonClicked;

    protected override void Awake()
    {
        base.Awake();
        Destination = GameObject.Find("Destination");
        Canon = GameObject.Find("Canon");
        OnLeftButtonClicked = Canon.GetComponent<CanonController>().SpawnPlayer;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftButtonClicked?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            for (int i = 0, j = enemyCount / 2; i < enemyCount; i++, j--)
            {
                var enemyStartPos = new Vector3(Destination.transform.position.x + j, 0f, Destination.transform.position.z - (i % 3));
                Quaternion enemyQuaternion = Quaternion.Euler(0f, 180f, 0f);
                Instantiate(enemyPrefab, enemyStartPos, enemyQuaternion);
            }
        }
    }
}
