using UnityEngine;

public class DestinationController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject;
            player.SetActive(false);
        }
    }
}
