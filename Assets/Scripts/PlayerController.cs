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
        transform.LookAt(destination.transform.position);
    }
}
