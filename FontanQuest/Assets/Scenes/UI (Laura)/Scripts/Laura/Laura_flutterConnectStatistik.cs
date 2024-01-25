using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Laura_flutterConnectStatistik : MonoBehaviour
{
    public string stepcount;
    public delegate void NewStepValueEvent(string step);
    public event NewStepValueEvent NewStepValue;
    public TextMeshProUGUI TextDisplay = null;
    private flutterCommunication flutterCommunication;

    // Start is called before the first frame update
    void Start()
    {
        //stepcount = "0";
        TextDisplay = GameObject.Find("StepUpdate").GetComponent<TextMeshProUGUI>();
        flutterCommunication = GameObject.Find("GameObject").GetComponent<flutterCommunication>();
        flutterCommunication.NewStepValue += HandleSteps;
    }

    public void HandleSteps(string steps)
    {
        flutterCommunication.NewStepValue -= HandleSteps;
        int currentSteps = int.Parse(steps);
        TextDisplay.text = currentSteps.ToString();
        /// do what ever you want with steps and current steps
    }

}