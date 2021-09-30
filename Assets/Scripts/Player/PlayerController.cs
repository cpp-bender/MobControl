using UnityEngine;

public class PlayerController : MonoBehaviour, IEntity
{
    [SerializeField] PlayerData playerData;

    public bool CanMove { get => canMove; set => canMove = value; }
    
    private GameObject destination;
    private Rigidbody body;
    private bool canMove = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        destination = GameManager.Instance.Destination;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            Move();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject;
            PoolManager.Instance.ReturnToPool(enemy, PoolGameObjectType.Enemy);
        }
        else if (collision.gameObject.CompareTag("Huge Enemy"))
        {
            GameObject hugeEnemy = collision.gameObject;
            if (hugeEnemy.transform.localScale == Vector3.one / 2f)
            {
                SetScale(hugeEnemy, Vector3.one);
                PoolManager.Instance.ReturnToPool(hugeEnemy, PoolGameObjectType.HugeEnemy);
            }
            else
            {
                hugeEnemy.transform.localScale -= (Vector3.one / 10f);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ResetVelocityTo(Vector3.zero);
        }
        else if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Huge Enemy"))
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void Move()
    {
        if (canMove)
        {
            Vector3 dirToTarget = (destination.transform.position - transform.position).normalized;
            transform.Translate(dirToTarget * Time.deltaTime * playerData.MoveSpeed, Space.World);
            var destinationPos = new Vector3(destination.transform.position.x, 0f, destination.transform.position.z);
            transform.LookAt(destinationPos);
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
