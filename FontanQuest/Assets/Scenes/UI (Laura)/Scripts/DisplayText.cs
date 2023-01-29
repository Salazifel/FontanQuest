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
    public int prev;
    public int current = 0;
    // Start is called before the first frame update
    void Start()
    {
        textField.text = PlayerPrefs.GetString("activity");
    }

    // Update is called once per frame
    public void Create()
    {
        int.TryParse(display.text, out current);
        int.TryParse(textField.text, out prev);
        textField.text = (prev + current) + " min";
        PlayerPrefs.SetString("activity", textField.text);
        PlayerPrefs.Save(); 
    }
}
