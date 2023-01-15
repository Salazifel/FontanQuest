using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCountDownManager : MonoBehaviour
{
    private SingleCountDown _countDown;
    public event CoundDownFinished CoundDownFinishedEvent;
    public delegate void CoundDownFinished ();
    // Start is called before the first frame update
    void Start()
    { 
        _countDown = GetComponent<SingleCountDown>();
    }


    public void StartCountdown()
    {
       _countDown.StartCountDown();
    }

    public void CurrentCountDownFinished()
    {
        CoundDownFinishedEvent?.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
