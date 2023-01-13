using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHouse : MonoBehaviour
{
    public GameObject WorkerPrefab;
    private int factor;
    private string BuildingType;
    private string ObjectFolder;
    private int Level;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<buildingDataSys>().set_ObjectFolder(ObjectFolder);
        GetComponent<buildingDataSys>().set_BuildingType(BuildingType);
        
        // instantiate a worker prefab with the correct position of the spawnpoint
        for (int i = 0; i < factor; i++)
        {
            GameObject tmp = Instantiate(WorkerPrefab, transform.Find("SpawnPoint").transform.position, Quaternion.identity);
        }
        // get transform.position from the child object "SpawnPoint"
        //tmp.transform.position = transform.Find("SpawnPoint").transform.position;
    }

    public void set_Level(int Factor, string BuildingType, int Level, string ObjectFolder)
    {
        // from the house Lvl X script
        this.factor = Factor;
        this.BuildingType = BuildingType;
        this.Level = Level;
        this.ObjectFolder = ObjectFolder;
    }
}
