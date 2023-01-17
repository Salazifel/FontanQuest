using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageEventSystem : MonoBehaviour
{
    private List<string> PlayerData = new List<string>();

    private List<bool> SentMessages = new List<bool>();

    private int NumberOfMessager = 2;

    private bool GameFullyLoaded = false;

    void Awake()
    {
        resetPlayerData();

        GameFullyLoaded = false;

        for (int i = 0; i < NumberOfMessager; i++)
        {
            SentMessages.Add(false);
        }
    }

    void Update()
    {
        if (GameFullyLoaded == false)
        {
            return;
        }
    
        // Message 1
        if (this.PlayerData[1] == "true")
        {
            Debug.Log("First time!");
            SentMessages[0] = true;
            GetComponent<MessageDisplay>().new_Message("Welcome to Fontan Quest! King Peter-Emiliard of Butherodelid, the Great, the Lion, the Sublime, the Merry, the... [I'll skip that for now] has sent me to a distant island as a summoned one. You are to build a small outpost here in his name. But we have very few raw materials at our disposal. Wood, stone and food could be obtained by settlers by constructing buildings over the hammer symbol. In houses live the workers. The main building increases your stock, the tavern the speed of the workers and the stables offer some surprises. Maybe you should build a house first?", "Advisor");
            this.PlayerData[1] = "false";
        }

        // Message 2
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        if (SentMessages[0] == true && buildings.Length > 0 && SentMessages[1] == false)
        {
            Debug.Log("Evil Wizard is not amused!");
            GetComponent<MessageDisplay>().new_Message("Hey! What are you doing next to my secret wizard island. I am Radion of Sorrel, the Grand Magus of the Black Guild! I don't tolerate neighbors who might see me walking around my island in my pajamas!", "EvilWizard");
            SentMessages[1] = true;
        }
    }

    // Load and Save stuff
    public void Receive_PlayerData_fromSaveGameDataCS(List<string> pD)
    {
        if (pD.Count < 3)
        {
            Debug.Log("PlayerData.Count < 3");
            return;
        }

        this.PlayerData.Clear();
        this.PlayerData.Add(pD[0]);
        this.PlayerData.Add(pD[1]);
        this.PlayerData.Add(pD[2]);

        GameFullyLoaded = true;
    }

    public List<string> Send_PlayerData_toSaveGameDataCS()
    {
        return this.PlayerData;
    }

    private void resetPlayerData()
    {
        this.PlayerData.Clear();
        this.PlayerData.Add("PlayerName");
        this.PlayerData.Add("true");
        this.PlayerData.Add("false");
    }

    // structure of PlayerData:
    // 0: PlayerName
    // 1: FirstPlay (true/false)
    // 2: EverReachedResourceLimit (true/false)

    public void set_GameFullyLoaded(bool b)
    {
        GameFullyLoaded = b;
    }
}
