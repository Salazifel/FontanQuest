using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    private GameObject prefab;

    private int ObjectLvl;
    private string ObjectType;
    private string ObjectFolder;
    private GameObject MasterData;
    private GameObject Canvas;
    public bool placable;

    // Start is called before the first frame update

    void Awake()
    {
        MasterData = GameObject.Find("MasterData");
    }

    void Start()
    {
        placable = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        transform.position = GameObject.Find("BuildPos").transform.position;
        
        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))
        {
            //transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))
        {
            //transform.position = hit.point;
        }
        /*
        if (Input.GetMouseButton(0))
        {
            if (placable == true)
            {
                Debug.Log(ObjectFolder + " " + ObjectType);
                prefab = Resources.Load("Buildings/"+ ObjectFolder + "/" + "Constr" + ObjectFolder + "Lvl" + ObjectLvl) as GameObject;
                GameObject newBuilding = Instantiate(prefab, transform.position, transform.rotation);
                Destroy(gameObject);

                // needed to save and load the game
                name = "Constr" + ObjectFolder + "Lvl" + ObjectLvl;
                newBuilding.GetComponent<buildingDataSys>().set_BuildingType(name);
                newBuilding.GetComponent<buildingDataSys>().set_WearDown(0);

                GameObject.Find("Canvas").GetComponent<build>().hide_all_Buttons();
                GameObject.Find("Canvas").GetComponent<BuildButton>().Finalize_built();
            }
        }
        */
        if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }
    }

    void set_placeable(bool b)
    {
        placable = b;
    }

    public void set_Level(int lvl, string type, string folder)
    {
        ObjectLvl = lvl;
        ObjectType = type;
        ObjectFolder = folder;
    }

    public bool get_placable()
    {
        return placable;
    }
}
