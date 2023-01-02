using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrWoodCutter : MonoBehaviour
{
    public GameObject MasterData; // access to main Data of the game
    public GameObject FinalBuilding; // Drag and drop prefab of the final building

    // once the GameObject is initiated, a new task for building is created
    public void Start()
    {
        // MasterData.GetComponent<SavingGameData>().set_newObject(gameObject);

        Debug.Log("New Task should be created");
        Vector3 GoToPos = transform.Find("GoToPos").transform.position; // gets the transform.position of the cild "GoToPos", an invisible realworld position
        // creates a new task in the ToDoList, which is queued in the end
        MasterData.GetComponent<ToDoList>().NewTask("Worker", "build", 0, GoToPos, 3, gameObject);
        // string PersonTag, string capability, int failedAttempts, Vector3 pos, float time, string emitter
    }

    // defines what happens if the task stops midway
    public void OnCancellation()
    {
        MasterData.GetComponent<Ressources>().ChangeRessources(10, 10, 0, 0);
        // MasterData.GetComponent<SavingGameData>().remove_Object(gameObject);
        Destroy(gameObject);
    }

    // defines what happens during the time of execution
    public void OnExecution()
    {
        Debug.Log("House is being build");
        OnTaskCompletion();
    }

    // defines what happens once the task is done
    public void OnTaskCompletion()
    {
        // MasterData.GetComponent<SavingGameData>().remove_Object(gameObject);
        Destroy(gameObject);
        GameObject newBuilding = Instantiate(FinalBuilding, transform.position, transform.rotation);

        // needed for the game to save and load:
        gameObject.GetComponent<buildingDataSys>().set_BuildingType("WoodCutterLvl1");
        gameObject.GetComponent<buildingDataSys>().set_WearDown(0);

        // MasterData.GetComponent<SavingGameData>().set_newObject(newBuilding);
        BroadcastMessage("Free_Worker");
    }

    public void give_BuildingType()
    {
        // MasterData.GetComponent<SavingGameData>().receive_buildingType("WoodCutterLvl1ConstructionSite");
    }

}
