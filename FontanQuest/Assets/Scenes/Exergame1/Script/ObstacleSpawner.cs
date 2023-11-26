using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f; // Adjust this to control the interval between obstacle spawns
    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObstacle();
            timeSinceLastSpawn = 0f;
        }
    }

    // Adjust near and far clipping planes in the camera's settings
    // Ensure obstacles are spawned at an appropriate Z-position
    void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0f); // Adjust the Z-position as needed
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

}
