using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;
using System;

public class SavingGameData : MonoBehaviour
{
    public GameObject WorkerPrefab;
    private string savefile;
    public List<string> InGameOtherObjectsTags;

    [Serializable] 
    public class GameData
    {
        public int wood;
        public int stone;
        public int food;
        public int gold;

        public List<InGameBuilding> InGameBuildings;
        public List<InGameOtherObject> InGameOtherObjects;

        public List<string> PlayerData;
    }

    [Serializable]
    public class InGameBuilding
    {
        public Vector3 pos;
        public Quaternion rotation;
        public string ObjectFolder;
        public string ObjectType;
        public float wearDown;
    }

    [Serializable]
    public class InGameOtherObject
    {
        public Vector3 pos;
        public Quaternion rotation;
        public string ObjectFolder;
        public string ObjectType;
        public string status;
    }

    public void save_Game()
    {
        // delte old save file
        if (File.Exists(savefile))
        {
            File.Delete(savefile);
        }

        File.WriteAllText(savefile, get_GameData());
    }

    public void load_Game()
    {
        if (File.Exists(savefile) == false)
        {
            return;
        }
        
        string fileContents = File.ReadAllText(savefile);
        GameData gameData = JsonUtility.FromJson<GameData>(fileContents);

        Debug.Log(gameData);
        // load ressources
        ResourceContainer.setRes(gameData.wood, gameData.stone, gameData.food, gameData.gold);
        
        // run the Receive_PlayerData_fromSaveGameDataCS function in MessageEventSystem.cs and hand over the PlayerData
        GetComponent<MessageEventSystem>().Receive_PlayerData_fromSaveGameDataCS(gameData.PlayerData);

        // load buildings
        //Debug.Log("test: " + Resources.Load("Buildings/" + gameData.InGameBuildings[0].ObjectFolder + "/" + gameData.InGameBuildings[0].ObjectType).GetType());
        for (int i = 0; i < gameData.InGameBuildings.Count; i++)
        {
            if (gameData.InGameBuildings[i].ObjectFolder != "" || gameData.InGameBuildings[i].ObjectType != "")
            {
                GameObject tmp = Instantiate(Resources.Load("Buildings/" + gameData.InGameBuildings[i].ObjectFolder + "/" + gameData.InGameBuildings[i].ObjectType) as GameObject);
                tmp.transform.position = gameData.InGameBuildings[i].pos;
                tmp.transform.rotation = gameData.InGameBuildings[i].rotation;
                tmp.GetComponent<buildingDataSys>().set_WearDown((int) gameData.InGameBuildings[i].wearDown);
            }
        }

        // load other objects
        for (int i = 0; i < gameData.InGameOtherObjects.Count; i++)
        {
            if (gameData.InGameOtherObjects[i].ObjectFolder != "" || gameData.InGameOtherObjects[i].ObjectType != "")
            {
                GameObject tmp = Instantiate(Resources.Load("OtherObjects/" + gameData.InGameOtherObjects[i].ObjectFolder + "/" + gameData.InGameOtherObjects[i].ObjectType) as GameObject);
            tmp.transform.position = gameData.InGameOtherObjects[i].pos;
            tmp.transform.rotation = gameData.InGameOtherObjects[i].rotation;
            tmp.GetComponent<OtherObjectsDataSys>().set_Status(gameData.InGameOtherObjects[i].status);
            }
        }

        StartCoroutine("AutoSave");
    }


    void Awake()
    {
        // Instantiate a worker at the start of the game
        GameObject FirstWorkerPosition = GameObject.Find("FirstWorkerPosition");
        GameObject worker = Instantiate(WorkerPrefab, FirstWorkerPosition.transform.position, Quaternion.identity);

        savefile = Application.persistentDataPath + "/gamedata.json";
        Debug.Log(Application.persistentDataPath);

        InGameOtherObjectsTags.Add("Tree");
        InGameOtherObjectsTags.Add("TreeTrunk");

        //load_Game();
        //StartCoroutine("AutoSave");
    }

    public string get_GameData()
    {
        GameData gameData = new GameData();
        gameData.InGameBuildings = new List<InGameBuilding>();
        gameData.InGameOtherObjects = new List<InGameOtherObject>();
        gameData.PlayerData = new List<string>();

        // get the PlayerData
        gameData.PlayerData = GetComponent<MessageEventSystem>().Send_PlayerData_toSaveGameDataCS();

        // Getting the ressources
        int[] res = ResourceContainer.getRes();
        gameData.wood = res[0];
        gameData.stone = res[1];
        gameData.food = res[2];
        gameData.gold = res[3];

        // get all buildings
        GameObject [] buildings = GameObject.FindGameObjectsWithTag("Building");
        for (int i = 0; i < buildings.Length; i++)
        {            
            InGameBuilding tmp = CreateInGameBuilding(buildings[i]);
            gameData.InGameBuildings.Add(tmp);
        }

        // get all other InGameObjects
        for (int i = 0; i < InGameOtherObjectsTags.Count; i++)
        {
            GameObject [] otherObjects = GameObject.FindGameObjectsWithTag(InGameOtherObjectsTags[i]);
            for (int n = 0; n < otherObjects.Length; n++)
            {
                InGameOtherObject tmp = CreateInGameOtherObject(otherObjects[n]);
                gameData.InGameOtherObjects.Add(tmp);
            }
        }


        Debug.Log(gameData.InGameBuildings.Count);
        
        string JasonString = JsonUtility.ToJson(gameData);
        return JasonString;
    }

    public InGameBuilding CreateInGameBuilding(GameObject gO)
    {
        InGameBuilding tmp = new InGameBuilding();

        tmp.pos = gO.transform.position;
        tmp.rotation = gO.transform.rotation;

        tmp.ObjectFolder = gO.GetComponent<buildingDataSys>().get_ObjectFolder();
        tmp.ObjectType = gO.GetComponent<buildingDataSys>().get_BuildingType();
        tmp.wearDown = gO.GetComponent<buildingDataSys>().get_WearDown();

        return tmp;
    }

    public InGameOtherObject CreateInGameOtherObject(GameObject gO)
    {
        InGameOtherObject tmp = new InGameOtherObject();

        tmp.pos = gO.transform.position;
        tmp.rotation = gO.transform.rotation;
        tmp.ObjectFolder = gO.GetComponent<OtherObjectsDataSys>().get_ObjectFolder();
        tmp.ObjectType = gO.GetComponent<OtherObjectsDataSys>().get_ObjectType();
        tmp.status = gO.GetComponent<OtherObjectsDataSys>().get_Status();

        return tmp;
    }

    IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            save_Game();
            Debug.Log("GameSaved");
        }
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