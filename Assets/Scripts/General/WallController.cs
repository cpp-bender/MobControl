using System.Collections;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public enum DoublingValue
    {
        x2 = 2,
        x3 = 3,
        x6 = 6,
    };

    [SerializeField] WallData wallData;
    [SerializeField] DoublingValue doublingValue;
    [SerializeField] bool canMove;

    private void OnEnable()
    {
        if (canMove)
        {
            StartCoroutine(MoveBetweenRoutine());
        }
    }

    private IEnumerator MoveBetweenRoutine()
    {
        while (true)
        {
            Vector3 startPos = new Vector3(-wallData.MoveBetween, transform.position.y, transform.position.z);
            float interpolation = Mathf.PingPong(Time.time * wallData.MoveBetweenSpeed, 1);
            Vector3 targetPos = new Vector3(wallData.MoveBetween, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(startPos, targetPos, interpolation);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0, j = (int)doublingValue / 2; i < (int)doublingValue; i++, j--)
            {
                var spawnPos = other.transform.position + Vector3.forward * 1.5f + Vector3.right * j;
                GameObject go = PoolManager.Instance.Get(PoolGameObjectType.Player);
                go.SetActive(true);
                go.transform.position = spawnPos;
                j--;
            }
        }
    }
}
