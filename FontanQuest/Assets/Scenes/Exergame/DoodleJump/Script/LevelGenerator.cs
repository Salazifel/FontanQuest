using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject normalPlatformPrefab;
    public GameObject specialPlatformPrefab;
    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public float specialPlatformProbability = 0.00001f; // Adjust this probability as needed

    // Start is called before the first frame update
    void Start()
    {

        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            // Decide whether to instantiate a normal or special platform
            GameObject platformPrefab = Random.value < specialPlatformProbability ? specialPlatformPrefab : normalPlatformPrefab;

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

        }

    }


}
