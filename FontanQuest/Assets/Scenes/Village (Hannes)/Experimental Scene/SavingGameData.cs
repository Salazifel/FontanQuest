using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class SavingGameData : MonoBehaviour
{
    private string savefile;
    public List<string> InGameOtherObjectsTags;

    public class GameData
    {
        public int wood;
        public int stone;
        public int food;
        public int gold;

        public List<InGameBuilding> InGameBuildings; // = new List<InGameObjects>();
        public List<InGameOtherObject> InGameOtherObjects;
        // Dictionary<InGameObjects, InGameObjects> DictInGameObjects = new Dictionary<InGameObjects, InGameObjects>();   
    }

    public class InGameBuilding
    {
        public Vector3 pos;
        public Quaternion rotation;
        public string ObjectType;
        public float wearDownV;
    }

    public class InGameOtherObject
    {
        public Vector3 pos;
        public Quaternion rotation;
        public string ObjectType;
        public string status;
    }

    public void save_Game()
    {
        File.WriteAllText(savefile, get_GameData());
    }

    public void load_Game()
    {
        if (File.Exists(savefile))
        {
            string fileContents = File.ReadAllText(savefile);
        }
    }

    void Awake()
    {
        savefile = Application.persistentDataPath + "/gamedata.json";
        Debug.Log(Application.persistentDataPath);

        InGameOtherObjectsTags.Add("Tree");
        // InGameOtherObjectsTags.Add("TreeTrunk");
    }

    public string get_GameData()
    {
        GameData gameData = new GameData();

        // Getting the ressources
        gameData.wood = transform.parent.GetComponent<Ressources>().wood;
        gameData.stone = transform.parent.GetComponent<Ressources>().wood;
        gameData.food = transform.parent.GetComponent<Ressources>().wood;
        gameData.gold = transform.parent.GetComponent<Ressources>().wood;

        // get all buildings
        GameObject [] buildings = GameObject.FindGameObjectsWithTag("building");
        for (int i = 0; i < buildings.Length; i++)
        {
            gameData.InGameBuildings.Add(CreateInGameBuilding(buildings[i]));

        }
        // get all other InGameObjects

        for (int i = 0; i < InGameOtherObjectsTags.Count; i++)
        {
            GameObject [] otherObjects = GameObject.FindGameObjectsWithTag(InGameOtherObjectsTags[i]);
            for (int n = 0; n < otherObjects.Length; n++)
            {
                gameData.InGameOtherObjects.Add(CreateInGameOtherObject(otherObjects[n]));
            }
        }


        string JasonString = JsonUtility.ToJson(gameData);
        return JasonString;
    }

    public InGameBuilding CreateInGameBuilding(GameObject gO)
    {
        InGameBuilding tmp = new InGameBuilding();

        tmp.pos = gO.transform.position;
        tmp.rotation = gO.transform.rotation;
        tmp.ObjectType = gO.GetComponent<buildingDataSys>().get_BuildingType();
        tmp.wearDownV = gO.GetComponent<buildingDataSys>().get_WearDown();

        return tmp;
    }

    public InGameOtherObject CreateInGameOtherObject(GameObject gO)
    {
        InGameOtherObject tmp = new InGameOtherObject();

        tmp.pos = gO.transform.position;
        tmp.rotation = gO.transform.rotation;
        tmp.ObjectType = gO.GetComponent<OtherObjectsDataSys>().get_ObjectType();
        tmp.status = gO.GetComponent<OtherObjectsDataSys>().get_Status();

        return tmp;
    }
}













    /*
    public string buildingTypeGiven;

    List<InGameObject> InGameObjectsList = new List<InGameObject>();

    public class InGameObject
    {
        public Vector3 pos;
        public Quaternion rotation;
        public string buildingType;

        public InGameObject(Vector3 newPos, Quaternion newRotation, string newBuildingType)
        {
            pos = newPos;
            rotation = newRotation;
            newBuildingType = newBuildingType;
        }

        public bool CompareTo(InGameObject other)
        {
            if (other == null)
            {
                return false;
            }

            if (other.pos == pos && other.rotation == rotation && other.buildingType == buildingType)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string get_bType()
        {
            return buildingType;
        }
    }

    public void set_newObject(GameObject gO)
    {
        gO.BroadcastMessage("give_BuildingType");
        InGameObjectsList.Add(new InGameObject(gO.transform.position, gO.transform.rotation, buildingTypeGiven));
    }

    public void remove_Object(GameObject gO)
    {
        gO.BroadcastMessage("give_BuildingType");
        InGameObject igO = new InGameObject(gO.transform.position, gO.transform.rotation, buildingTypeGiven);

        for (int i = 0; i < InGameObjectsList.Count; i++)
        {
            if (InGameObjectsList[i].CompareTo(igO));
            {
                InGameObjectsList.RemoveAt(i);
                break;
            }
        }
    }

    public void receive_buildingType(string btype)
    {
        Debug.Log(btype);
        buildingTypeGiven = btype;
    }

    public void save_Data()
    {
        int wood;
        int stone;
        int food;
        int gold;

        for (int i = 0; i < InGameObjectsList.Count; i++)
        {
            // goes through all objects to be saved
        }
    }

    void Update()
    {
        Debug.Log("##### BEGIN #####");
        for (int i = 0; i < InGameObjectsList.Count; i++)
        {
            Debug.Log(InGameObjectsList[i].get_bType());
        }
        Debug.Log("##### END #####");
 
        GameObject newObject = GameObject.Find("Cube");

        InGameObjectsList.Add(new InGameObject(newObject.transform.position, newObject.transform.rotation, "test"));
    }*/