using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskContainer : MonoBehaviour
{
    public string PersonTag;
    public string capability;
    public int failedAttemps;
    public Vector3 pos;
    public float time;
    public GameObject emitter; // the one triggering the task
    public GameObject SelectedPerson;

    void SetValues(Task task)
    {
            PersonTag = task.PersonTag;
            capability = task.capability;
            failedAttemps = task.failedAttemps;
            pos = task.pos;
            time = task.time;
            emitter = task.emitter;
    }
}