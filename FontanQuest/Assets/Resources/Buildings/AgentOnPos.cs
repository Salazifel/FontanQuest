using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AgentOnPos : MonoBehaviour
{
    public Collider DesignatedWorkerCollider;

    private SphereCollider trigger;
    public GameObject DesignatedWorker;

    private bool triggered = false;
    private bool taskDone;

    /*
    private void OnTriggerEnter(Collider OtherObject)
    {
        if (DesignatedWorker != null)
        {
            Debug.Log("Something touched me: " + DesignatedWorker.name + OtherObject.name);
            if (DesignatedWorkerCollider == OtherObject)
            {
                triggered = true;
                Debug.Log("Reached!");
                DesignatedWorker.SendMessage("StopPath");
                transform.parent.SendMessage("OnExecution");
            }
        }
    }*/

    private void OnTriggerEnter(Collider other) {

        /*
        if (triggered == true)
        {
            Debug.Log("Still here!");
            StartCoroutine(StartTask());
        }
        */

        if (triggered == false && DesignatedWorkerCollider == other && taskDone == false) 
        {
            Debug.Log("Reached!");
            //StartTask();
            triggered = true;
        }
    }

    void FixedUpdate()
    {
        if (triggered == true && taskDone == false)
        {
            Debug.Log("Remains");
            StartTask();
        }
    }

    void StartTask()
    {
        DesignatedWorker.SendMessage("StopPath");
        transform.parent.SendMessage("OnExecution");
        taskDone = true;
        Debug.Log("task done");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Worker") && triggered == true && DesignatedWorkerCollider == other)
        {
            Debug.Log("Left!");
            triggered = false;
        }
    }

    void Awake()
    {
        trigger = GetComponent<SphereCollider>();
        Debug.Log(trigger);
    }

    public void Set_DesignatedWorker(GameObject DWorker)
    {
        Debug.Log("Roger that. Designated worker is: " + DWorker.name);
        DesignatedWorker = DWorker;
        DesignatedWorkerCollider = DWorker.GetComponent<Collider>();
        taskDone = false;
    }

    public void Free_Worker()
    {
        DesignatedWorker.SendMessage("SetIdle");
        // Destroy(transform.parent.gameObject);
    }
}
