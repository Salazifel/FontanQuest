using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Task
    {
        public string PersonTag;
        public string capability;
        public int failedAttemps;
        public Vector3 pos;
        public float time;
        public GameObject emitter; // the one triggering the task
        public GameObject SelectedPerson;
    }

public class ToDoList : MonoBehaviour
{    //public Queue ToDoListQu = new Queue();
    // Queue ToDoListQu = new Queue();
    // Queue FailedToListQu = new Queue();
    public GameObject TaskContainer;
    public GameObject[] tasks;

    private float timerTargetTime = 0.0f;

    private TextMeshProUGUI ToDoListText; // Label to display the current ToDoList
    
    public static ToDoList current; // event system once an agent reaches something

    public void NewTask(string PersonTag, string capability, int failedAttemps, Vector3 pos, float time, GameObject emitter)
    {
        if (failedAttemps < 5)
        {
            Task task = new Task();
            task.PersonTag = PersonTag;
            task.capability = capability;
            task.failedAttemps = failedAttemps;
            task.pos = pos;
            task.time = time;
            task.emitter = emitter;

            GameObject CurrentTask;
            CurrentTask = Instantiate(TaskContainer);
            CurrentTask.SendMessage("SetValues", task);
        }
        else
        {
            Debug.Log("Task failed more than 5 times and is cancelled");
            emitter.SendMessage("OnCancellation");
        }
    }

    Task GetPerson(Task task)
    { // Function explanation: searches for a person with that tag and returns one, if he/she is not busy
        // searches the scene for all "people" with a specific tag
        GameObject[] people;
        people = GameObject.FindGameObjectsWithTag(task.PersonTag);
        // goes through the list of people with that tag to find a non-busy one
        for (int i = 0; i < people.Length; i++)
        {
            bool status = people[i].GetComponent<PersonStatus>().busy;
            if (status == false)
            {
                // an idle person with the given tag was found and the private variable SelectedPerson is updated
                task.SelectedPerson = people[i];
                // the function returns true and the task distribution can continue
                Debug.Log("A free worker was found!");
                return task;
            }
        }
        Debug.Log("No free worker could be found");
        // no idle person with the given tag was found so the function returns false
        return task;
    }

    void CheckToDoList()
    {
        tasks = GameObject.FindGameObjectsWithTag("Task");
        // Debug.Log("ToDoList is being checked: " + tasks.Length);

        if (tasks.Length > 0)
        {
            Task task = new Task(); 

            for (int i = 0; i < tasks.Length; i ++)
            {
                if (tasks[i].GetComponent<TaskContainer>().SelectedPerson == null)
                {
                    task = assignTask(tasks[i]);
                    if (GetPerson(task).SelectedPerson != null) // means that an idle person of the task's nametag was found
                    {
                        tasks[i].GetComponent<TaskContainer>().SelectedPerson = task.SelectedPerson;
                        DequeueTask(task, tasks[i]);
                    }
                    //return;
                }
            }
            

        }
        // Debug.Log("2doListChecked");
    }

    Task assignTask(GameObject TaskContainer)
    {
        Task task = new Task();
        task.PersonTag      = TaskContainer.GetComponent<TaskContainer>().PersonTag;
        task.capability     = TaskContainer.GetComponent<TaskContainer>().capability;
        task.failedAttemps  = TaskContainer.GetComponent<TaskContainer>().failedAttemps;
        task.pos            = TaskContainer.GetComponent<TaskContainer>().pos;
        task.time           = TaskContainer.GetComponent<TaskContainer>().time;
        task.emitter        = TaskContainer.GetComponent<TaskContainer>().emitter;

        return task;
    }

    void DequeueTask(Task task, GameObject CurrentTaskContainer)
    {
        // Gets the emitter of the current task in question
        // GameObject emitter = GameObject.Find(task.emitter);


        task.SelectedPerson.SendMessage("SetBusy");
        task.emitter.BroadcastMessage("Set_DesignatedWorker", CurrentTaskContainer.GetComponent<TaskContainer>().SelectedPerson);
        Debug.Log("Designated worker for " + task.capability + " is " + task.SelectedPerson);

        if (task.SelectedPerson.GetComponent<MoveTo>().GoTo(task.pos) == false)
        {
            Debug.Log("Not reachable target");
            task.failedAttemps++;
            task.SelectedPerson.SendMessage("SetIdle");
            NewTask(task.PersonTag, task.capability, task.failedAttemps, task.pos, task.time, task.emitter);
            // the target point is not reachable
        }

        Destroy(CurrentTaskContainer);

        // StartCoroutine(CheckAgentStatus(1, 1, SelectedPerson, task)); // relict from the timer approach 13.12.2022
    }

    void Update()
    {
        timerTargetTime -= Time.deltaTime;

        if (timerTargetTime <= 0.0f)
        {
            timerTargetTime = 1.0f;
            CheckToDoList();
        }
    }
}

/*
 * 
    // ########################## TIMER ###########################
    Timer AgentStatusCountOneDown(Timer timer, int length, int reducer, GameObject person, Task task)
    {
        if (timer.currentSecondsLeft > 0)
        {
            Debug.Log(timer.currentSecondsLeft);
            timer.currentSecondsLeft--;
        }
        else
        {
            timer.run = false;
            AgentStatusResult(length, reducer, person, task);
        }
        return timer;
    }

    IEnumerator CheckAgentStatus(int length, int reducer, GameObject person, Task task)
    {
        Timer timer = new Timer();
        timer.run = true;
        timer.currentSecondsLeft = length;

        while (timer.run)
        {
            timer = AgentStatusCountOneDown(timer, length, reducer, person, task);
            yield return new WaitForSeconds(reducer);
        }
    }

    void AgentStatusResult(int length, int reducer, GameObject person, Task task)
    {
        if (person.GetComponent<UnityEngine.AI.NavMeshAgent>().remainingDistance > 0)
        {
            // Gets the emitter of the current task in question
            GameObject emitter = GameObject.Find(task.emitter);
            emitter.SendMessage("OnTaskCompletion");
        }
        else
        {
            StartCoroutine(CheckAgentStatus(length, reducer, person, task));
        }
    }

    // ########################## END ###########################
*/

