using System.Collections;
using UnityEngine;

public class DestinationController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject;
            player.GetComponent<PlayerController>().CanMove = false;
            GameManager.Instance.AddScore(1);
            StartCoroutine(WaitRoutine(.5f, player, PoolGameObjectType.Player));
        }
        else if (other.gameObject.CompareTag("Huge Player"))
        {
            var hugePlayer = other.gameObject;
            hugePlayer.GetComponent<PlayerController>().CanMove = false;
            GameManager.Instance.AddScore(5);
            StartCoroutine(WaitRoutine(.5f, hugePlayer, PoolGameObjectType.HugePlayer));
        }
    }

    private IEnumerator WaitRoutine(float waitTime, GameObject gameObject, PoolGameObjectType poolGameObject)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        gameObject.GetComponent<PlayerController>().CanMove = true;
        gameObject.transform.localScale = Vector3.one;
        PoolManager.Instance.ReturnToPool(gameObject,poolGameObject);
    }
}
