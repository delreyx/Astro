using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBoss : MonoBehaviour
{
    public GameObject bossPrefab; // The prefab of the boss to spawn
    public Transform playerTransform; // The player's transform component

    public float spawnInterval = 40f; // Time interval between boss spawns

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBoss();
            timer = 0f;
        }
    }

    private void SpawnBoss()
    {
        Vector3 spawnPosition = playerTransform.position + Vector3.up; // Spawning on top of the player's position
        Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
    }
}