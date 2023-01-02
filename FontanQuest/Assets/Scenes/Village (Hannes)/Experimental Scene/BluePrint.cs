using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    public GameObject MasterData;
    public GameObject Canvas;
    private bool placable;

    // Start is called before the first frame update

    void Awake()
    {
        MasterData = GameObject.Find("MasterData");
    }

    void Start()
    {
        placable = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))
        {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))
        {
            transform.position = hit.point;
        }

        if (Input.GetMouseButton(0))
        {
            if (placable == true)
            {
                GameObject newBuilding = Instantiate(prefab, transform.position, transform.rotation);
                Destroy(gameObject);

                // needed to save and load the game
                newBuilding.GetComponent<buildingDataSys>().set_BuildingType("WoodCutterLvl1ConstrSite");
                newBuilding.GetComponent<buildingDataSys>().set_WearDown(0);

                GameObject.FindGameObjectWithTag("Menubuttons").SetActive(false);
                GameObject.Find("Canvas").GetComponent<Build_Woodcutter>().Finalize_built();
            }
        }

        if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }
    }

    void set_placeable(bool b)
    {
        placable = b;
    }
}
