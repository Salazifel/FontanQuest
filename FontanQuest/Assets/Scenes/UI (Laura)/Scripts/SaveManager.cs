using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;
    public TextMeshProUGUI textField;
    public string text;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(Helper.Serialize<SaveState>(state));
        StartCoroutine("UpdateTime");
        textField = GameObject.Find("Timeplay (TMP)").GetComponent<TextMeshProUGUI>();
    }

     public void Save()
    {
        PlayerPrefs.SetString("save",Helper.Serialize<SaveState>(state));

    }

    //Load the previous save state
    public void Load()
    {
        if(PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("Saving the new game");
        }
    }

    //Check if the color is owned
    private IEnumerator UpdateTime()
    {
        textField.text = " Gesamte Spielzeit: " + state.minutes.ToString() + "min " + state.seconds.ToString() + "sec";
        while (true)
        {
            yield return new WaitForSeconds(1);
            state.playtime += 1;
            state.seconds =  (state.playtime % 60);
            Debug.Log(state.seconds);
            state.minutes =  (state.playtime / 60) % 60;
            state.hours = (state.playtime / 3600) % 24;
            Save();
            
        }   
            

    }
}
