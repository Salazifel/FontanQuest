using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Laura_PlayTime : MonoBehaviour
{
    public int playtime;
    public int seconds;
    public int minutes;
    public int hours;
    public TextMeshProUGUI textField;
    public string text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Playtimer");
        textField = GameObject.Find("Timeplay (TMP)").GetComponent<TextMeshProUGUI>();
            
    }
    
    public IEnumerator Playtimer()
    {
        while (true)
        {   
            yield return new WaitForSeconds(1);
            playtime += 1;
            seconds = (playtime % 60);
            minutes = (playtime / 60) % 60;
            hours = (playtime / 3600) % 24;

            
        }
    }

    void OnGUI()
    {
        textField.text = "Spielzeit: " + minutes.ToString() + "min " + seconds.ToString() + "sec";

    }
}
