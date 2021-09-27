using UnityEngine;

public class DestinationController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject;
            player.SetActive(false);
        }
    }
}
