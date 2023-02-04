using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public string text;
    public TMP_InputField display;
    int savedMinutes, current;

    // Start is called before the first frame update
    void Start()
    {
        textField.text = PlayerPrefs.GetString("activity");
    }

    // Update is called once per frame
    public void Create()
    {
        int.TryParse(display.text, out current);
        int.TryParse(textField.text, out savedMinutes);
        textField.text = (savedMinutes + current) + " min";
        PlayerPrefs.SetString("activity", textField.text);
        PlayerPrefs.Save(); 
    }
}
