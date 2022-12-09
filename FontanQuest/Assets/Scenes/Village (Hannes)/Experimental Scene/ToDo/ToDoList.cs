using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task
    {
        public string PersonTag;
        public string capability;
        public int failedAttemps;
        public Vector3 pos;
        public float time;
        public string emitter; // the one triggering the task
    }

public class ToDoList : MonoBehaviour
{
    private GameObject SelectedPerson;
    Queue ToDoListQu = new Queue();
    Queue FailedToListQu = new Queue();
    private TextMeshProUGUI ToDoListText; // Label to display the current ToDoList

    public void NewTask(string PersonTag, string capability, int failedAttempts, Vector3 pos, float time, string emitter)
    {
        Task task = new Task();
        task.PersonTag = PersonTag;
        task.capability = capability;
        task.failedAttemps = failedAttempts;
        task.pos = pos;
        task.time = time;
        task.emitter = emitter;

        QueueTask(task);
    }

    IEnumerator StartToListChecking()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            CheckToDoList();
        }
    }

    bool GetPerson(string tag)
    { // Function explanation: searches for a person with that tag and returns one, if he/she is not busy

        // searches the scene for all "people" with a specific tag
        GameObject[] people;
        people = GameObject.FindGameObjectsWithTag(tag);
        // goes through the list of people with that tag to find a non-busy one
        for (int i = 0; i < people.Length; i++)
        {
            bool status = people[i].GetComponent<PersonStatus>().busy;
            if (status == false)
            {
                // an idle person with the given tag was found and the private variable SelectedPerson is updated
                SelectedPerson = people[i];
                // the function returns true and the task distribution can continue
                Debug.Log("A free worker was found!");
                return true;
            }
        }
        Debug.Log("No free worker could be found");
        // no idle person with the given tag was found so the function returns false
        return false;
    }

    void CheckToDoList()
    {
        Debug.Log(ToDoListQu.Count);
        if (ToDoListQu.Count > 0)
        {
            Task task = (Task) ToDoListQu.Peek();
            if (GetPerson(task.PersonTag) == true)
            {
                DequeueTask(task);
            }
        }

        if (FailedToListQu.Count > 0)
        {
            Task task = (Task)FailedToListQu.Peek();
            if (GetPerson(task.PersonTag) == true)
            {
                DequeueTask(task);
            }
        }
        // Debug.Log("2doListChecked");
    }

    void QueueTask(Task task)
    {
        if (task.failedAttemps > 5)
        {
            FailedToListQu.Enqueue(task);
            Debug.Log("Task failed more than 5 times");
            return;
        }
        ToDoListQu.Enqueue(task);
        CheckToDoList();

        // helpers
        // Task tmp = (Task)ToDoListQu.Peek();
        // Debug.Log(tmp.capability);
        // Debug.Log(ToDoListQu.Count);
    }

    void DequeueTask(Task task)
    {
        if (task.failedAttemps > 50)
        {
            FailedToListQu.Dequeue();
            // task.emitter.GetComponent<main>().OnCancellation();
            return;
        }
        GameObject person = SelectedPerson;
        person.GetComponent<PersonStatus>().busy = true;
        person.GetComponent<MoveTo>().GoTo(task.pos);

        // Vector3 stuckpos;

        /*
        while ((person.transform.position.x != task.pos.x) && (person.transform.position.y != task.pos.y))
        {
            stuckpos = person.transform.position;
            yield return new WaitForSeconds(1);
            if (person.transform.position == stuckpos)
            {
                person.GetComponent<PersonStatus>().busy = false;
                task.failedAttemps += 1;
                QueueTask(task);
                break;
            }
        }*/
        //person.GetComponent<task.capability>().Execute(task.time);
        GameObject.Find(task.emitter).GetComponent<ConstrWoodCutter>().OnTaskCompletion();
        ToDoListQu.Dequeue();
    }

    void Awake()
    {
        ToDoListText = GameObject.Find("ToDoList").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        // StartCoroutine(StartToListChecking());
    }

    void Update()
    {
        try
        {
            Task task = (Task) ToDoListQu.Peek();
            ToDoListText.text = task.capability;
        }
        catch
        {

        }


    }
}

