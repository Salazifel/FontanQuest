using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBuild : MonoBehaviour
{
    private GameObject MasterData; // access to main Data of the game
    public GameObject FinalBuilding; // Drag and drop prefab of the final building

    private string ObjectFolder;
    private string BuildingType; // set in the set_Level function onAwake through the HouseLvlX script
    private int BuildingLvl; // set in the set_Level function onAwake through the HouseLvlX script
    private string[] prices;

    // once the GameObject is initiated, a new task for building is created
    public void Start()
    {
        MasterData = GameObject.Find("MasterData");
        //Debug.Log("New Task should be created");
        Vector3 GoToPos = transform.Find("GoToPos").transform.position; // gets the transform.position of the cild "GoToPos", an invisible realworld position
        // creates a new task in the ToDoList, which is queued in the end
        MasterData.GetComponent<ToDoList>().NewTask("Worker", "build", 0, GoToPos, 3, gameObject);
        // string PersonTag, string capability, int failedAttempts, Vector3 pos, float time, string emitter

        // needed for the game to save and load:
        gameObject.GetComponent<buildingDataSys>().set_BuildingType(BuildingType);
        gameObject.GetComponent<buildingDataSys>().set_ObjectFolder(ObjectFolder);

        // get the string[] of prices of the building using ReturnUpkeep(string buildingName, int buildingLevel) from the MasterData's Prices.cs
        prices = MasterData.GetComponent<Prices>().ReturnUpkeep(ObjectFolder, BuildingLvl);
    }

    // defines what happens if the task stops midway
    public void OnCancellation()
    {
        // call the changeRes function in the public static class ResourceContainer.cs to change the ressources. The values are the prices of the building
        ResourceContainer.changeRes(int.Parse(prices[0]), int.Parse(prices[1]), int.Parse(prices[2]), int.Parse(prices[3]));
        Destroy(gameObject);
    }

    // defines what happens during the time of execution
    public void OnExecution()
    {
        //Debug.Log("House is being build");
        OnTaskCompletion();
    }

    // defines what happens once the task is done
    public void OnTaskCompletion()
    {
        // Destroy the current construction site and instantiate the final building
        Destroy(gameObject);
        GameObject newBuilding = Instantiate(FinalBuilding, transform.position, transform.rotation);
        // free the worker
        BroadcastMessage("Free_Worker");
    }

    public void set_Level(string BuildingType, int Level, string oF)
    {
        // gets the factors from the house level script
        this.BuildingLvl = Level;
        this.BuildingType = BuildingType;
        this.ObjectFolder = oF;
    }
}
