using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private GameObject destination;
    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        destination = GameManager.Instance.Destination;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ResetVelocityTo(Vector3.zero);
        }
    }

    private void Move()
    {
        Vector3 dirToTarget = (destination.transform.position - transform.position).normalized;
        transform.Translate(dirToTarget * Time.deltaTime * playerData.MoveSpeed, Space.World);
        var destinationPos = new Vector3(destination.transform.position.x, 0f, destination.transform.position.z);
        transform.LookAt(destinationPos);
    }

    private void ResetVelocityTo(Vector3 newVeclocity)
    {
        body.velocity = newVeclocity;
    }
}
