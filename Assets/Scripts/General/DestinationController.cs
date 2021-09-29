using UnityEngine;

public class DestinationController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject;
            PoolManager.Instance.ReturnToPool(player, PoolGameObjectType.Player);
        }
    }
}
