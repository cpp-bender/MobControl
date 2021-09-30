using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine;
using System;

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

    private float moveBetween;

    private void OnEnable()
    {
        if (Random.Range(0, 100 / 75) == 0)
        {
            SetWallMoveBetweenValue();
            StartCoroutine(MoveBetweenRoutine());
            doublingValue = DoublingValue.x3;
            return;
        }
        doublingValue = DoublingValue.x2;
    }

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0, j = (int)doublingValue / 2; i < (int)doublingValue; i++, j--)
            {
                var spawnPos = other.transform.position + Vector3.forward * 1.5f + Vector3.right * j;
                GameObject player = PoolManager.Instance.Get(PoolGameObjectType.Player);
                player.transform.position = spawnPos;
                j--;
            }
        }
        else if (other.CompareTag("Huge Player"))
        {
            for (int i = 0, j = (int)doublingValue / 2; i < (int)doublingValue; i++, j--)
            {
                var spawnPos = other.transform.position + Vector3.forward * 2f + Vector3.left * j;
                GameObject hugePlayer = PoolManager.Instance.Get(PoolGameObjectType.HugePlayer);
                hugePlayer.transform.position = spawnPos;
                j--;
            }
        }
    }

    private void SetWallMoveBetweenValue()
    {
        moveBetween = transform.position.x;
    }

    private IEnumerator MoveBetweenRoutine()
    {
        while (true)
        {
            Vector3 startPos = new Vector3(-moveBetween, transform.position.y, transform.position.z);
            float interpolation = Mathf.PingPong(Time.time * wallData.MoveBetweenSpeed, 1);
            Vector3 targetPos = new Vector3(moveBetween, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(startPos, targetPos, interpolation);
            yield return null;
        }
    }
}
