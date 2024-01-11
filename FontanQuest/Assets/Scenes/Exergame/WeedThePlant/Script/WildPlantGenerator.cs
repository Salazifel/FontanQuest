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
        StartCoroutine(GenerateWildPlantCoroutine());
    }

    // Update is called once per frame
    /*
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= GenerateInterval)
        {
            GenerateWildPlant();
            timeSinceLastSpawn = 0f;

        }
    }
    */

    IEnumerator GenerateWildPlantCoroutine()
    {
        while (true)
        {
            GenerateWildPlant();
            yield return new WaitForSeconds(GenerateInterval);
        }
    }

    void GenerateWildPlant()
    {
        int r = Random.Range(0, WildPlants.Length);
        GameObject NewWildPlant = Instantiate(WildPlants[r], transform);
        NewWildPlant.transform.localPosition = new Vector3(Random.Range(-179, 174), Random.Range(-145, 80), 0);
        TimeLastShows += Time.deltaTime;

        StartCoroutine(DisableAfterTime(NewWildPlant, TimePlantShows));
    }

    IEnumerator DisableAfterTime(GameObject plant, float TimeToShow)
    {
        yield return new WaitForSeconds(TimeToShow);
        plant.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered OnTriggerEnter");
        if (other.gameObject.CompareTag("left"))
        {
            Debug.Log("Left");
        }
        else if (other.gameObject.CompareTag("right"))
        {
            Debug.Log("Right");
        }
        else if (other.gameObject.CompareTag("both"))
        {
            Debug.Log("Both");
        }
        else if (other.gameObject.CompareTag("PlantA"))
        {
            Debug.Log("PlantA");
        }
        else if (other.gameObject.CompareTag("PlantB"))
        {
            Debug.Log("PlantB");
        }
        else
        {
            Debug.Log("Collided with an unknown tag: " + other.tag);
        }
    }

}
