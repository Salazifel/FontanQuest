using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public Transform parentObject; // The parent GameObject containing children
    private GameObject Pet;
    private GameObject lastTile;
    private Transform spawnedObjectsParent; // Parent for the spawned objects
    private GameObject spawnedObject;
    public GameObject prefabWithSpecificScript; // Assign the prefab with the specific script

    private Vector3 respawnPos;

    public float spawnInterval = 10.0f;
    // public float spawnDistance = 5.0f;

    private float nextSpawnTime = 0f;

    void Start()
    {
        Pet = GameObject.Find("Pet");
        lastTile = GameObject.Find("Last_Tile");
        respawnPos = lastTile.transform.position;

        // Create an empty GameObject to serve as the parent for spawned objects
        spawnedObjectsParent = new GameObject("SpawnedObjectsParent").transform;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Debug.Log("Spawning object at time: " + Time.time);
            SpawnRandomChild();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnRandomChild()
    {
        if (parentObject != null && parentObject.childCount > 0)
        {
            // Select a random child from the parent
            Transform randomChild = parentObject.GetChild(Random.Range(0, parentObject.childCount));

            // Spawn the selected child
            Vector3 spawnPosition = new Vector3(Random.Range(-15.0f, 15.0f), 0f, transform.position.z + Random.Range(-15.0f, 15.0f));

            // Check the distance between spawn position and Pet
            if (Vector3.Distance(spawnPosition, Pet.transform.position) > 70.0f)
            {
                // Instantiate the prefab using the gameObject property of the Transform
                spawnedObject = Instantiate(randomChild.gameObject, spawnPosition, Quaternion.identity);

                // Make it a child of the spawnedObjectsParent
                spawnedObject.transform.parent = spawnedObjectsParent;

                // Add the specific script to the spawned object
                spawnedObject.AddComponent<PetRunner>();
            }

            // Check the distance between the spawner and lastTile
            if (spawnedObject != null && Vector3.Distance(spawnedObject.transform.position, respawnPos) < 5f)
            {
                // Destroy the spawned object
                Destroy(spawnedObject);
            }
        }
    }
}
