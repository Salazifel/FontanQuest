using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouTubeHouseScript : MonoBehaviour
{
    MessageWindow messageWindow;
    public string typeOfButton;
    void Start()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }
    public void StartVideo()
    {
        messageWindow.SetupMessageWindow("Filmpalast", "Willkommen in unserem Stadtkino. Willst du mit uns etwas schauen und dabei Sport machen?", "Gerade nicht", messageWindow.DeactivateMessageWindow, "Ja!", StartVidoeRightButtonClick, null, null, MessageWindow.Character_options.Character_Female_Druid, AnimationLibrary.Animations.Talk, null);
    }

    public void OpenBuildWindow()
    {
        if (typeOfButton == "BuildBuilding")
        {
            buildYouTubeBuilding();
        } 

        if (typeOfButton == "StartGame")
        {
            StartVideo();
        }
    }

    private void StartVidoeRightButtonClick()
    {
         SceneManager.Load("VideoSelection");
    }

    public void buildYouTubeBuilding()
    {
        messageWindow.SetupMessageWindow("Filmpalast", "Schaust du auch so gerne Videos, wie ich? Ich habe gehoert der Koenig mag es auch? Ich kann gerne mit meinem Kino hierher ziehen!", null, null, null, null, "Klasse!", buildYouTubeBuildingRightButtonClick, MessageWindow.Character_options.Character_Female_Druid, AnimationLibrary.Animations.Talk, null);    
    }

    private void buildYouTubeBuildingRightButtonClick()
    {
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null)
        {
            builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
        }
        builtBuildings.YouTubeHouse = true;
        SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
        GameObject.Find("GameData").GetComponent<DisplayInteractiveButtons>().displayAvailableButtons();
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().displayBuiltBuildings();
        messageWindow.DeactivateMessageWindow();
    }
}
