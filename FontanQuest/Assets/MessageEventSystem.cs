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
            GetComponent<MessageDisplay>().new_Message("Willkommen bei Fontan Quest! Koenig Peter-Emiliard von Butherodelid, der Große, der Loewe, der Erhabene, der Froehliche, der... [das überspringe ich jetzt mal] hat euch den Auftrag gegeben diese für den Handel wichtige Insel zu erschliessen. Ihr sollt hier in seinem Namen einen kleinen Außenposten errichten. Aber wir haben nur sehr wenige Rohstoffe zur Verfügung. Holz, Stein und Nahrung koennen die Siedler erhalten, indem sie über dem Hammersymbol Gebaeude errichten. In den Haeusern wohnen die Arbeiter. Das Hauptgebaeude erhoeht den Vorrat, die Taverne die Geschwindigkeit der Arbeiter und die Staelle bieten einige Ueberraschungen. Vielleicht sollten Sie zuerst ein Haus bauen?", "Advisor");
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
