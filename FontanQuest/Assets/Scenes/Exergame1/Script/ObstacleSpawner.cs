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

    void SpawnObstacle()
    {
        // Calculate the spawn position off-screen
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, -10f); // Move along the negative Z-axis (towards the camera)

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        // Debug.Log(obstaclePrefab.name + " spawned at position: " + spawnPosition);
        Debug.Log(obstaclePrefab.name + " transform position: " + transform.position);
    }

}
