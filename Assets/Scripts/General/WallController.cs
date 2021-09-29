using UnityEngine;

public class WallController : MonoBehaviour
{
    public enum DoublingValue
    {
        x2 = 2,
        x3 = 3,
        x6 = 6,
    };

    [SerializeField] DoublingValue doublingValue;

    private void Update()
    {
        //TODO: Make the wall move between 2 points
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
