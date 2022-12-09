using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private bool run;
    private int currentSecondsLeft;
    public delegate void FinishedEvent();
    public event FinishedEvent Finished;
    // Start is called before the first frame update
    void Start()
    {
        run = true;
        currentSecondsLeft = 5;
        StartCoroutine(timer());
    }

    void CountOneDown()
    {
        if (currentSecondsLeft > 0)
        {
            Debug.Log(currentSecondsLeft);
            currentSecondsLeft--;
        }
        else
        {
            run = false;
            Finished? Invoke;
            Event();
        }
    }

    IEnumerator timer()
    {
        while (run)
        {
            CountOneDown();
            yield return new WaitForSeconds(1);
        }
    }

    void Event()
    {
        Debug.Log("Done");
    }
}
