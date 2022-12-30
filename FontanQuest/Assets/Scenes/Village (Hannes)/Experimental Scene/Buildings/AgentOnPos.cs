using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AgentOnPos : MonoBehaviour
{
    public Collider DesignatedWorkerCollider;
    public GameObject DesignatedWorker;

    private void OnTriggerEnter(Collider OtherObject)
    {
        if (DesignatedWorker != null)
        {
            Debug.Log("Something touched me: " + DesignatedWorker.name + OtherObject.name);
            if (DesignatedWorkerCollider == OtherObject)
            {
                Debug.Log("Reached!");
                DesignatedWorker.SendMessage("StopPath");
                transform.parent.SendMessage("OnExecution");
            }
        }
    }

    public void Set_DesignatedWorker(GameObject DWorker)
    {
        Debug.Log("Roger that. Designated worker is: " + DWorker.name);
        DesignatedWorker = DWorker;
        DesignatedWorkerCollider = DWorker.GetComponent<Collider>();
    }

    public void Free_Worker()
    {
        DesignatedWorker.SendMessage("SetIdle");
        // Destroy(transform.parent.gameObject);
    }
}
