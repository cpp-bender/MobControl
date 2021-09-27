using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEntity
{
    [SerializeField] EnemyData enemyData;

    private GameObject canon;

    private void Awake()
    {
        canon = GameManager.Instance.Canon;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject;
            player.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void Move()
    {
        transform.Translate(transform.forward * enemyData.MoveSpeed * Time.deltaTime, Space.World);
    }
}
