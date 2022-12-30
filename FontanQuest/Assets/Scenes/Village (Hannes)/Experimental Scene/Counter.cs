using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CounterTim
{
    public bool run;
    public int currentSecondsLeft;
}

public class Counter : MonoBehaviour
{
    private int currentSecondsLeft;
    //public delegate void FinishedEvent();
    //public event FinishedEvent Finished;
    // Start is called before the first frame update
    void Start()
    {
         // StartCoroutine(CheckAgentStatus(5, 1));
        // StartCoroutine(Countdown(6, 2));
    }



    CounterTim AgentStatusCountOneDown(CounterTim counter)
    {
        if (counter.currentSecondsLeft > 0)
        {
            Debug.Log(counter.currentSecondsLeft);
            counter.currentSecondsLeft--;
        }
        else
        {
            counter.run = false;
            AgentStatusResult();
        }
        return counter;
    }

    IEnumerator CheckAgentStatus(int length, int reducer)
    {
        CounterTim counter = new CounterTim();
        counter.run = true;
        counter.currentSecondsLeft = length;

        while (counter.run)
        {
            counter = AgentStatusCountOneDown(counter);
            yield return new WaitForSeconds(reducer);
        }
    }

    void AgentStatusResult()
    {
        Debug.Log("Done");
    }
}
