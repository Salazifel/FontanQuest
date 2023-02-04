using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class flutterCommunication : MonoBehaviour
{
    public string stepcount;
    public delegate void NewStepValueEvent(string step);
    public event NewStepValueEvent NewStepValue;
    public TextMeshProUGUI TextDisplay =null;

    //test 
    private bool test = false; // indicates that the test state is active and will trigger every interpolation second an new step event
    private float time = 0; 
    private float interpolation = 0.5f; //intervall between two new step events for the test phase
    // Start is called before the first frame update
    void Start()
    {
        stepcount = "0";
     //   TextDisplay = GameObject.Find("Fact (TMP)").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (test)
        {
          TestSteps();
        }
    }

    public void sendStep(string message)
    {
        stepcount = message;

        //triggers an event with the string of the steps to all subscriber 
        NewStepValue?.Invoke(message);

        //sets the text of an label to the current step count
        if(TextDisplay != null)
        {
            TextDisplay.text = stepcount;
        }
    }

    /// <summary>
    /// method only for testing
    /// It will trigger an NewStepValue event every interpolation seconds 
    /// first step will have as message 1 the next will have 2 etc.
    /// </summary>
    public void TestSteps()
    {
        time += Time.deltaTime;
        if (test)
        {
            if (time > interpolation)
            {
                stepcount = (int.Parse(stepcount) + 1).ToString();
                time = 0;
                NewStepValue?.Invoke(stepcount);
            }
        }
    }
}
