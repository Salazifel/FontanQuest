using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFarm : MonoBehaviour
{
    private int factor;
    private string BuildingType;
    private string ObjectFolder;
    private int Level;

    private GameObject MasterData;

    private bool taskEmitted = false;

    void Start()
    {
        MasterData = GameObject.Find("MasterData");

        // needed for the game to save and load:
        GetComponent<buildingDataSys>().set_ObjectFolder(ObjectFolder);
        GetComponent<buildingDataSys>().set_BuildingType(BuildingType);
    }

    public void set_Level(int Factor, string BuildingType, int Level, string ObjectFolder)
    {
        // from the house Lvl X script
        this.factor = Factor;
        this.BuildingType = BuildingType;
        this.Level = Level;
        this.ObjectFolder = ObjectFolder;
    }

    void Update()
    {
        int[] res = ResourceContainer.getRes();
        int[] maxRes = ResourceContainer.getMaxRes();

        if (res[2] < maxRes[2] && taskEmitted == false)
        {
            StartCoroutine(Task());
        }
    }

    // create a IEnumerator for the task
    public IEnumerator Task()
    {
        taskEmitted = true;
        Vector3 GoToPos = transform.Find("GoToPos").transform.position;
        MasterData.GetComponent<ToDoList>().NewTask("Worker", "farm", 0, GoToPos, 3, gameObject);
        yield return new WaitForSeconds(1);
    }

    public void OnCancellation()
    {
        // nothing happens
    }

    public void OnExecution()
    {
        StartCoroutine(Wait());
    }

    public void OnTaskCompletion()
    {
        ResourceContainer.changeRes(0, 0, 1 * factor, 0);
        BroadcastMessage("Free_Worker");
        taskEmitted = false;
    }

    private IEnumerator Wait()
    {
        Debug.Log("Task started");
        yield return new WaitForSeconds(30);
        OnTaskCompletion();
    }
}
