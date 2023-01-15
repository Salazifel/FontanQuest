using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageEventSystem : MonoBehaviour
{
    private List<string> PlayerData = new List<string>();

    private List<bool> SentMessages = new List<bool>();

    private int NumberOfMessager = 2;

    void Start()
    {
        resetPlayerData();

        for (int i = 0; i < NumberOfMessager; i++)
        {
            SentMessages.Add(false);
        }
    }

    void Update()
    {
        // Message 1
        if (this.PlayerData[1] == "true")
        {
            Debug.Log("First time!");
            SentMessages[0] = true;
            GetComponent<MessageDisplay>().new_Message("Willkommen bei Fontan Quest! König Peter-Emiliard von und zu Butherodelid, der Große, der Löwe, der Erhabene, der Lustige, der ... [ich überspringe das jetzt mal] hat ich als gesannten auf eine ferne Insel gesannt. Ihr sollt in seinem Namen hier einen kleinen Außenposten bauen. Doch wir haben sehr wenig Rohstoffe zur Verfügung. Holz, Stein und Essen könnten wir durch Siedler erwirtschaften indem Ihr die Gebäude über das Hammersymbol baut. In Häusern wohnen die Arbeiter. Das Hauptgebäude erhöht euer Lager, die Taverne die Geschwindigkeit der Arbeiter und die Ställe bieten einige Überraschungen. Vielleicht solltet Ihr erstmal ein Haus bauen?", "Advisor");
            this.PlayerData[1] = "false";
        }

        // Message 2
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        if (SentMessages[0] == true && buildings.Length > 0 && SentMessages[1] == false)
        {
            Debug.Log("Evil Wizard is not amused!");
            GetComponent<MessageDisplay>().new_Message("He! Was macht ihr da neben meiner geheimen Zaubererinsel. Ich bin Radion von Sauerampfer, der Großmagus der schwarzen Gilde! Ich dulde keine Nachbarn, die mich im Schlafanzug auf meiner Insel herumspazieren sehen könnten!", "EvilWizard");
            SentMessages[1] = true;
        }
    }

    // Load and Save stuff
    public void Receive_PlayerData_fromSaveGameDataCS(List<string> PlayerData)
    {
        if (PlayerData.Count < 3)
        {
            Debug.Log("PlayerData.Count < 3");
            return;
        }

        this.PlayerData.Clear();
        this.PlayerData.Add(PlayerData[0]);
        this.PlayerData.Add(PlayerData[1]);
        this.PlayerData.Add(PlayerData[2]);
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
}
