using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private GameObject destination;

    private void Awake()
    {
        destination = GameManager.Instance.Destination;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dirToTarget = (destination.transform.position - transform.position).normalized;
        transform.Translate(dirToTarget * Time.deltaTime * playerData.MoveSpeed, Space.World);
        var destinationPos = new Vector3(destination.transform.position.x, 0f, destination.transform.position.z);
        transform.LookAt(destinationPos);
    }
}
