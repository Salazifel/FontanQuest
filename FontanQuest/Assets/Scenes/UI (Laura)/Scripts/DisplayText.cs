using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public int text;
    public TMP_InputField display;

    // Start is called before the first frame update
    void Start()
    {
        textField.text = PlayerPrefs.GetString("activity");
        
    }

    // Update is called once per frame
    public void Create()
    {
     //   display.text =  display.text;
        textField.text = display.text + " min";
        PlayerPrefs.SetString("activity", textField.text);
        PlayerPrefs.Save();
    }
}
