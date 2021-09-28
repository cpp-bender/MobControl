﻿using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEntity
{
    [SerializeField] EnemyData enemyData;

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject;
            player.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void Move()
    {
        if (transform.position.z > 1f)
        {
            transform.Translate(transform.forward * enemyData.MoveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            StartCoroutine(RemoveRoutine(1.5f));
        }
    }

    private IEnumerator RemoveRoutine(float waitDelay)
    {
        yield return new WaitForSeconds(waitDelay);
        gameObject.SetActive(false);
    }
}