using System.Collections;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] CanonControllerData canonData;

    private float playerNextSpawnTime;
    private float canonMoveThreshold;

    private void Update()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            Move();
        }
    }

    private void Start()
    {
        SetCanonThreshold();
    }

    private void Move()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        float canonPosX = transform.position.x + canonData.MoveSpeed * horizontalInput * Time.deltaTime;
        canonPosX = Mathf.Clamp(canonPosX, -canonMoveThreshold, canonMoveThreshold);
        transform.position = new Vector3(canonPosX, transform.position.y, transform.position.z);
    }

    private void SetCanonThreshold()
    {
        canonMoveThreshold = GameManager.Instance.Platform.transform.localScale.x * 2 * transform.localScale.x + (transform.localScale.x / 2);
    }

    public void SpawnPlayer()
    {
        if (Time.time >= playerNextSpawnTime)
        {
            var playerStartPos = new Vector3(transform.position.x, 0f, transform.position.z + 1f);
            GameObject player = Random.Range(0, 100 / canonData.HugePlayerSpawnPercentRate)
                == 0
                ? PoolManager.Instance.Get(PoolGameObjectType.HugePlayer)
                : PoolManager.Instance.Get(PoolGameObjectType.Player);
            player.transform.position = playerStartPos;
            playerNextSpawnTime = Time.time + canonData.PlayerRespawnTime;
            StartCoroutine(PushRoutine(player));
        }
    }

    private IEnumerator PushRoutine(GameObject player)
    {
        float interpolation = 0f;
        float frames = 0f;
        float maxFrames = canonData.PushRoutineFrameCount;
        var desiredPosition = player.transform.position + Vector3.forward * canonData.PushTo;
        while (interpolation <= 1f)
        {
            interpolation = frames / maxFrames;
            player.transform.position = Vector3.Lerp(player.transform.position, desiredPosition, interpolation);
            frames++;
            yield return null;
        }
    }
}
