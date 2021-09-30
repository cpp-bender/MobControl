using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEntity
{
    [SerializeField] EnemyData enemyData;

    public bool CanMove { get; set; }

    private GameObject canon;
    private Rigidbody body;

    private void Awake()
    {
        canon = GameManager.Instance.Canon;
        body = GetComponent<Rigidbody>();
        CanMove = true;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            CheckIfEnemyCanMove();
            Move();
        }
    }

    private void CheckIfEnemyCanMove()
    {
        if (transform.position.z < canon.transform.position.z + 2f)
        {
            CanMove = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            PoolManager.Instance.ReturnToPool(player, PoolGameObjectType.Player);
        }
        else if (collision.gameObject.CompareTag("Huge Player"))
        {
            GameObject hugePlayer = collision.gameObject;
            if (hugePlayer.transform.localScale == Vector3.one / 2f)
            {
                SetScale(hugePlayer, Vector3.one);
                PoolManager.Instance.ReturnToPool(hugePlayer, PoolGameObjectType.HugePlayer);
            }
            else
            {
                hugePlayer.transform.localScale -= (Vector3.one / 10f);
            }
        }
        else if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Huge Enemy"))
        {
            var enemy = collision.gameObject;
            body.velocity = Vector3.zero;
            enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ResetVelocityTo(Vector3.zero);
        }
    }

    public void Move()
    {
        if (CanMove)
        {
            transform.Translate(transform.forward * enemyData.MoveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            StartCoroutine(RemoveRoutine(.5f));
        }
    }

    private IEnumerator RemoveRoutine(float waitDelay)
    {
        yield return new WaitForSeconds(waitDelay);
        CanMove = true;
        if (gameObject.CompareTag("Enemy"))
        {
            PoolManager.Instance.ReturnToPool(gameObject, PoolGameObjectType.Enemy);
        }
        else if (gameObject.CompareTag("Huge Enemy"))
        {
            PoolManager.Instance.ReturnToPool(gameObject, PoolGameObjectType.HugeEnemy);
        }
    }

    public void SetScale(GameObject gameObject, Vector3 scale)
    {
        gameObject.transform.localScale = scale;
    }

    public void ResetVelocityTo(Vector3 newVelocity)
    {
        body.velocity = newVelocity;
    }
}
