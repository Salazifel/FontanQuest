using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPlantGenerator : MonoBehaviour
{
    public GameObject[] WildPlants;
    public float GenerateInterval;
    private float timeSinceLastSpawn = 0f;
    public float TimePlantShows;
    private float TimeLastShows = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= GenerateInterval)
        {
            GenerateWildPlant();
            timeSinceLastSpawn = 0f;

        }
    }

    void GenerateWildPlant()
    {
        int r = Random.Range(0, WildPlants.Length);
        GameObject NewWildPlant = Instantiate(WildPlants[r], transform);
        NewWildPlant.transform.localPosition = new Vector3(Random.Range(-179, 174), Random.Range(-145, 80), 0);
        TimeLastShows += Time.deltaTime;
        if (TimeLastShows >= TimePlantShows)
        {
            NewWildPlant.SetActive(false);
            TimeLastShows = 0f;
        }
    }


}
