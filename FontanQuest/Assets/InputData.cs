using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputData : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public static string input;
    //public Button InputData;

    void Start()
    {
        //InputData.gameObject.SetActive(false);
        textField = GameObject.Find("TimeData").GetComponent<TextMeshProUGUI>();
    }

    public void ReadStringInput(string s)
    { 
        input = s;
        Debug.Log(input);
        //textField.text = input;
    }
}
