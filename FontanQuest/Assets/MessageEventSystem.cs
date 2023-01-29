using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageEventSystem : MonoBehaviour
{
    private int currentSteps;

    private System.DateTime time_game_started;

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

        try
        {
            currentSteps = int.Parse(GameObject.Find("GameObject").GetComponent<flutterCommunication>().stepcount);
        }
        catch (System.Exception)
        {
            currentSteps = 0;
        }

        time_game_started = System.DateTime.Now;
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
            GetComponent<MessageDisplay>().new_Message("Willkommen bei Fontan Quest! Koenig Peter-Emiliard von Butherodelid, der Große, der Loewe, der Erhabene, der Froehliche, der... [das ueberspringe ich jetzt mal] hat euch den Auftrag gegeben diese fuer den Handel wichtige Insel zu erschliessen. Ihr sollt hier in seinem Namen einen kleinen Außenposten errichten. Aber wir haben nur sehr wenige Rohstoffe zur Verfuegung. Holz, Stein und Nahrung koennen die Siedler sammeln, indem sie ueber dem Hammersymbol Gebaeude errichten. In den Haeusern wohnen die Arbeiter. Das Hauptgebaeude erhoeht den Vorrat, die Taverne die Geschwindigkeit der Arbeiter und die Staelle bieten einige Ueberraschungen. Vielleicht sollten Sie zuerst ein Haus bauen?", "Advisor");
            this.PlayerData[1] = "false";
        }

        // Message 2
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        if (SentMessages[0] == true && buildings.Length > 0 && SentMessages[1] == false)
        {
            Debug.Log("Evil Wizard is not amused!");
            GetComponent<MessageDisplay>().new_Message("Hey! Was machst du neben meiner geheimen Zaubererinsel? Ich bin Radion von Sauerampfer, der Großmagus der Schwarzen Gilde! Ich dulde keine Nachbarn, die mich in meinem Pyjama auf meiner Insel herumlaufen sehen!", "EvilWizard");
            SentMessages[1] = true;
        }

        if (currentSteps > int.Parse(this.PlayerData[3]))
        {
            Debug.Log("Reward for steps!");
            int tmp = currentSteps - int.Parse(this.PlayerData[3]);
            int goldReward = (int) Mathf.Round( tmp / 100);
            if (goldReward > 0)
            {
                GetComponent<MessageDisplay>().new_Message("Oh Ihr seid wohl viel unterwegs, " + tmp + " Schritte habt Ihr seit eurem Letzten Versuch getan. Das entspricht " + goldReward + " Gold.", "Advisor");
                ResourceContainer.changeRes(0, 0, 0, goldReward);
                this.PlayerData[3] = currentSteps.ToString();
            }
        }
    }

    // Load and Save stuff
    public void Receive_PlayerData_fromSaveGameDataCS(List<string> pD)
    {
        if (pD.Count < 4)
        {
            Debug.Log("PlayerData.Count < 5");
            return;
        }

        this.PlayerData.Clear();
        // make a for loop for the length of pD
        for (int i = 0; i < pD.Count; i++)
        {
            this.PlayerData.Add(pD[i]);
        }
        GameFullyLoaded = true;

        //Debug.Log("PlayerData loaded: " + this.PlayerData[0] + ", " + this.PlayerData[1] + ", " + this.PlayerData[2] + ", " + this.PlayerData[3]);
    }

    public List<string> Send_PlayerData_toSaveGameDataCS()
    {
        add_time_played();
        return this.PlayerData;
    }

    private void resetPlayerData()
    {
        this.PlayerData.Clear();
        this.PlayerData.Add("PlayerName"); 
        this.PlayerData.Add("true");
        this.PlayerData.Add("false");
        this.PlayerData.Add("0");
        this.PlayerData.Add(System.DateTime.Now.ToString("dd/MM/yyyy"));
        // create variable System.TimeSpan that is empty
        System.TimeSpan tmp = new System.TimeSpan(0, 0, 0);
        this.PlayerData.Add(tmp.ToString());
    }

    // structure of PlayerData:
    // 0: PlayerName
    // 1: FirstPlay (true/false)
    // 2: EverReachedResourceLimit (true/false)
    // 3: number of steps since last entry to the screen
    // 4: last day played
    // 5: time played in total

    public void set_GameFullyLoaded(bool b)
    {
        GameFullyLoaded = b;
    }

    private void compare_today_to_last_date()
    {
        string today = System.DateTime.Now.ToString("dd/MM/yyyy");
        if (today != this.PlayerData[4])
        {
            this.PlayerData[4] = today;
        }
    }

    private void add_time_played()
    {
        System.TimeSpan elapsedTime = System.DateTime.Now - time_game_started;
        this.PlayerData[5] = (System.TimeSpan.Parse(this.PlayerData[5]) + elapsedTime).ToString();
        ResourceContainer.set__time_played(elapsedTime + System.TimeSpan.Parse(this.PlayerData[5]));
        Debug.Log(ResourceContainer.time_played.ToString());
    }
}
