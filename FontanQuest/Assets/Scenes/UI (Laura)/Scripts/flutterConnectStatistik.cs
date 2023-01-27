using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class flutterConnectStatistik : MonoBehaviour
{
    public string stepcount;
    public delegate void NewStepValueEvent(string step);
    public event NewStepValueEvent NewStepValue;
    public TextMeshProUGUI TextDisplay = null;

    // Start is called before the first frame update
    void Start()
    {
        stepcount = "0";
        TextDisplay = GameObject.Find("Fact (TMP)").GetComponent<TextMeshProUGUI>();
        PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
