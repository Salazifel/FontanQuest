using System.Collections;
using UnityEngine;

public class WildPlantGenerator : MonoBehaviour
{
    public GameObject[] WildPlants;
    public float GenerateInterval;
    public float TimePlantShows;
    private float TimeLastShows = 0f;
    private float timer;
    [SerializeField] GameObject SquatDown;
    [SerializeField] GameObject SquatDownWord;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndStart());
        SquatDown.SetActive(false);
        SquatDownWord.SetActive(false);
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

    IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(7f);
        StartCoroutine(GenerateWildPlantCoroutine());
    }
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
        NewWildPlant.transform.localPosition = new Vector3(Random.Range(-219, 217), Random.Range(-189, 121), 0);
        TimeLastShows += Time.deltaTime;

        SquatDown.SetActive(true);
        SquatDownWord.SetActive(true);

        StartCoroutine(DisableAfterTime(NewWildPlant, TimePlantShows));
    }

    IEnumerator DisableAfterTime(GameObject plant, float TimeToShow)
    {
        yield return new WaitForSeconds(TimeToShow);
        plant.SetActive(false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered OnCollisionEnter2D");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered OnTriggerEnter2D");
        if (collision.gameObject.CompareTag("left"))
        {
            Debug.Log("Left");
        }
        else if (collision.gameObject.CompareTag("right"))
        {
            Debug.Log("Right");
        }
        else if (collision.gameObject.CompareTag("both"))
        {
            Debug.Log("Both");
        }
        else if (collision.gameObject.CompareTag("PlantA"))
        {
            Debug.Log("PlantA");
        }
        else if (collision.gameObject.CompareTag("PlantB"))
        {
            Debug.Log("PlantB");
        }
        else
        {
            Debug.Log("Collided with an unknown tag: " + collision.tag);
        }
    }

}
