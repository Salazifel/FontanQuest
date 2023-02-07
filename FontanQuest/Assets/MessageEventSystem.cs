using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageEventSystem : MonoBehaviour
{
    private int currentSteps= 0;

    private System.DateTime time_game_started;

    private List<string> PlayerData = new List<string>();

    private List<bool> SentMessages = new List<bool>();

    private int NumberOfMessager = 13;

    private bool GameFullyLoaded = false;

    private flutterCommunication flutterCommunication;

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
            flutterCommunication = GameObject.Find("GameObject").GetComponent<flutterCommunication>();
            flutterCommunication.NewStepValue += HandleSteps;

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
            GetComponent<MessageDisplay>().new_Message("Willkommen bei Fontan Quest! Koenig Peter-Emiliard von Butherodelid, der Große, der Loewe, der Erhabene, der Froehliche, der... [das ueberspringe ich jetzt mal] hat euch den Auftrag gegeben diese fuer den Handel wichtige Insel zu erschliessen. Ihr sollt hier in seinem Namen einen kleinen Außenposten errichten. Aber wir haben nur sehr wenige Rohstoffe zur Verfuegung. Holz, Stein und Nahrung koennen die Siedler sammeln, indem sie ueber dem Hammersymbol Gebaeude errichten. In den Haeusern wohnen die Arbeiter. Diese sind gruen, wenn Sie nichts zu tun haben und rot, wenn sie eine Aufgabe erledigen. Das Hauptgebaeude erhoeht den Vorrat, die Taverne die Geschwindigkeit der Arbeiter und die Staelle bieten einige Ueberraschungen. Vielleicht sollten Sie zuerst ein Haus bauen?", "Advisor");
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
            int goldReward = (int) Mathf.Round( tmp / 1000);

            // limiting the gold reward to 3
            if (goldReward > 3)
            {
                goldReward = 3;
            }

            if (goldReward > 0)
            {
                GetComponent<MessageDisplay>().new_Message("Oh Ihr seid wohl viel unterwegs, " + tmp + " Schritte habt Ihr seit eurem Letzten Versuch getan. Das entspricht " + goldReward + " Gold.", "Advisor");
                ResourceContainer.changeRes(0, 0, 0, goldReward);
                this.PlayerData[3] = currentSteps.ToString();
            }
        }

        // 6: already sent a message about the first woodcutter? (true/false)
        if (this.PlayerData[6] == "false")
        {
            if (buildings.Length > 0)
            {
                foreach (GameObject building in buildings)
                {
                    if (building.GetComponent<buildingDataSys>().get_ObjectFolder() == "WoodCutter")
                    {
                        GetComponent<MessageDisplay>().new_Message("Ein Holzfaeller! Das ist ein guter Anfang. Holz ist ein wichtiger Rohstoff, den wir brauchen um Gebaeude zu errichten. Sobald ein freier Arbeiter zur Verfuegung steht wird er alle 30 Sekunden ein Holz produzieren und kann in der Zeit keine anderen Aufgaben erledigen. Die Taverne verkürzt diese Zeit", "Advisor");
                        this.PlayerData[6] = "true";
                    }
                }
            }
        }
        // 7: already sent a message about the first house? (true/false)
        if (this.PlayerData[7] == "false")
        {
            if (buildings.Length > 0)
            {
                foreach (GameObject building in buildings)
                {
                    if (building.GetComponent<buildingDataSys>().get_ObjectFolder() == "House")
                    {
                        GetComponent<MessageDisplay>().new_Message("Ein Haus! Endlich nicht mehr draussen schlafen. In den Haeusern wohnen die Arbeiter, in jedem Haus naehmlich einer", "Advisor");
                        this.PlayerData[7] = "true";
                    }
                }
            }
        }
        // 8: already sent a message about the first tavern? (true/false)
        if (this.PlayerData[8] == "false")
        {
            if (buildings.Length > 0)
            {
                foreach (GameObject building in buildings)
                {
                    if (building.GetComponent<buildingDataSys>().get_ObjectFolder() == "Tavern")
                    {
                        GetComponent<MessageDisplay>().new_Message("Eine Taverne! Das ist eine gute Idee. In der Taverne koennen die Arbeiter sich erholen und ihre Arbeit wird schneller erledigt", "Advisor");
                        this.PlayerData[8] = "true";
                    }
                }
            }
        }
        // 9: already sent a message about the first stable? (true/false)
        if (this.PlayerData[9] == "false")
        {
            if (buildings.Length > 0)
            {
                foreach (GameObject building in buildings)
                {
                    if (building.GetComponent<buildingDataSys>().get_ObjectFolder() == "Stable")
                    {
                        GetComponent<MessageDisplay>().new_Message("Die Staelle! Ach wie ich Pferde liebe. Nur der Ausritt auf dieser kleinen Insel ist etwas wenig...", "Advisor");
                        this.PlayerData[9] = "true";
                    }
                }
            }
        }
        // 10: already sent a message about the first mine? (true/false)
        if (this.PlayerData[10] == "false")
        {
            if (buildings.Length > 0)
            {
                foreach (GameObject building in buildings)
                {
                    if (building.GetComponent<buildingDataSys>().get_ObjectFolder() == "Mine")
                    {
                        GetComponent<MessageDisplay>().new_Message("Eine Mine! Das ist eine gute Idee. In der Mine koennen die Arbeiter Steine abbauen. Steine sind ein wichtiger Rohstoff, den wir brauchen um Gebaeude zu errichten. Sobald ein freier Arbeiter zur Verfuegung steht wird er alle 30 Sekunden ein Stein produzieren und kann in der Zeit keine anderen Aufgaben erledigen. Die Taverne verkürzt diese Zeit", "Advisor");
                        this.PlayerData[10] = "true";
                    }
                }
            }
        }
        // 11: already sent a message about the first farm? (true/false)
        if (this.PlayerData[11] == "false")
        {
            if (buildings.Length > 0)
            {
                foreach (GameObject building in buildings)
                {
                    if (building.GetComponent<buildingDataSys>().get_ObjectFolder() == "Farm")
                    {
                        GetComponent<MessageDisplay>().new_Message("Ein Bauernhof! Das ist eine gute Idee. Im Bauernhof koennen die Arbeiter Getreide ernten. Getreide ist ein wichtiger Rohstoff, den wir brauchen um Gebaeude zu errichten. Sobald ein freier Arbeiter zur Verfuegung steht wird er alle 30 Sekunden ein Getreide produzieren und kann in der Zeit keine anderen Aufgaben erledigen. Die Taverne verkürzt diese Zeit", "Advisor");
                        this.PlayerData[11] = "true";
                    }
                }
            }
        }
        // 12: already sent a message about the first main building? (true/false)
        if (this.PlayerData[12] == "false")
        {
            if (buildings.Length > 0)
            {
                foreach (GameObject building in buildings)
                {
                    if (building.GetComponent<buildingDataSys>().get_ObjectFolder() == "MainBuilding")
                    {
                        GetComponent<MessageDisplay>().new_Message("Oh, euer Haus ist groeßer als Meines ... achso, jetzt weiss ich warum. Zusaetzliche Resourcen koennen in der Burg gelagert werden und sie bietet Schutz bei Ueberfaellen. 'Leute packt die Mistgabeln weg, wir lassen die Burg stehen!'", "Advisor");
                        this.PlayerData[12] = "true";
                    }
                }
            }
        }
        // 13: number of buildings
        this.PlayerData[13] = buildings.Length.ToString();
        ResourceContainer.set__number_of_buildings(buildings.Length);
    }

    // Load and Save stuff
    public void Receive_PlayerData_fromSaveGameDataCS(List<string> pD)
    {
        if (pD.Count < NumberOfMessager)
        {
            Debug.Log("SaveFile is corrupted!");
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
        Debug.Log("resetPlayerData");
        this.PlayerData.Clear();
        // default is false, else, they are handled individually 
        for (int i = 0; i < NumberOfMessager + 1; i++)
        {
            this.PlayerData.Add("false");
        }

        this.PlayerData[0] = "PlayerName"; 
        this.PlayerData[1] = "true";
    
        this.PlayerData[3] = "0";
        this.PlayerData[4] = System.DateTime.Now.ToString("dd/MM/yyyy");
        // create variable System.TimeSpan that is empty
        System.TimeSpan tmp = new System.TimeSpan(0, 0, 0);
        this.PlayerData[5] = tmp.ToString();
        this.PlayerData[13] = "0"; 
    }

    // structure of PlayerData:
    // 0: PlayerName
    // 1: FirstPlay (true/false)
    // 2: EverReachedResourceLimit (true/false)
    // 3: number of steps since last entry to the screen
    // 4: last day played
    // 5: time played in total
    // 6: already sent a message about the first woodcutter? (true/false)
    // 7: already sent a message about the first house? (true/false)
    // 8: already sent a message about the first tavern? (true/false)
    // 9: already sent a message about the first stable? (true/false)
    // 10: already sent a message about the first mine? (true/false)
    // 11: already sent a message about the first farm? (true/false)
    // 12: already sent a message about the first main building? (true/false)
    // 13: number of buildings

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

    public void HandleSteps(string steps)
    {
        Debug.Log("Steps: " + steps);
        flutterCommunication.NewStepValue -= HandleSteps;
        currentSteps = int.Parse(steps);
    }
}
