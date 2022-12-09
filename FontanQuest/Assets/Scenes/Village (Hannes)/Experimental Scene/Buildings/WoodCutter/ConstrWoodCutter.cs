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
        Debug.Log("New Task should be created");
        Vector3 GoToPos = transform.Find("GoToPos").transform.position; // gets the transform.position of the cild "GoToPos", an invisible realworld position
        // creates a new task in the ToDoList, which is queued in the end
        MasterData.GetComponent<ToDoList>().NewTask("Worker", "build", 0, GoToPos, 3, transform.name);
        // string PersonTag, string capability, int failedAttempts, Vector3 pos, float time, string emitter
    }

    // defines what happens if the task stops midway
    public void OnCancellation()
    {

    }

    // defines what happens during the time of execution
    public void OnExecution()
    {
        Debug.Log("House is being build");
    }

    // defines what happens once the task is done
    public void OnTaskCompletion()
    {
        Instantiate(FinalBuilding, transform.position, transform.rotation);
        
    }

    IEnumerator WaitABit()
    {
        Debug.Log("Built");
        Instantiate(FinalBuilding, transform.position, transform.rotation);
        yield return new WaitForSeconds(3);
        Debug.Log("Built");
        
    }

    // Update is called once per frame
}
