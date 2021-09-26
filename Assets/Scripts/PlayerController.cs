using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private GameObject destination;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        destination = GameManager.Instance.Destination;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destination"))
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Move()
    {
        Vector3 dirToTarget = (destination.transform.position - transform.position).normalized;
        transform.Translate(dirToTarget * Time.deltaTime * playerData.MoveSpeed, Space.World);
        var destinationPos = new Vector3(destination.transform.position.x, 0f, destination.transform.position.z);
        transform.LookAt(destinationPos);
    }
}
