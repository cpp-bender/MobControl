﻿using System.Collections;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] CanonControllerData canonData;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        float canonPosX = transform.position.x + canonData.MoveSpeed * horizontalInput * Time.deltaTime;
        canonPosX = Mathf.Clamp(canonPosX, -canonData.MoveThreshold, canonData.MoveThreshold);
        transform.position = new Vector3(canonPosX, transform.position.y, transform.position.z);
    }

    public void SpawnPlayer()
    {
        var playerStartPos = new Vector3(transform.position.x, 0f, transform.position.z + 1f);
        GameObject player = Instantiate(canonData.PlayerPrefab, playerStartPos, Quaternion.identity);
        StartCoroutine(PushRoutine(player));
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
        Debug.Log("PushRoutine stopped");
    }
}
