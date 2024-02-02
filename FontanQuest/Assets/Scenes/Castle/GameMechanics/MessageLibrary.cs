using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MessageLibrary : MonoBehaviour
{
    public Dictionary<string, List<MessageObjectBlueprint.messageObject>> messageLibrary;
    private MessageWindow messageWindow;
    
    void Awake()
    {
        messageLibrary = new Dictionary<string, List<MessageObjectBlueprint.messageObject>>();
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
        AddBuildingMessages();
    } 

    // Building messages 
    void AddBuildingMessages()
    {
        AddWoodCutterMessages();
        AddStoneCutterMessage();
        AddFarmMessage();
        AddAsianMonkMessage();
        AddObstacleRunningMessage();
        AddYouTubeSceneMessage();
        AddMountainClimberMessage();
        AddDoodleJumpMessage();
        AddFitnessBoxingMessage();
        AddWeedThePlantMessage();
        AddHikingExergameMessage();
        AddParentsMarketKidsPerspectiveMessage();
    }

    void AddParentsMarketKidsPerspectiveMessage()
    {
        // Local function for the Var0 right button click action
        void Var0RightButtonClick()
        {
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.Market = 1; // Update the specific building status
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Local function for the Var1 right button click action
        void Var1RightButtonClick()
        {
            SceneManager.Load("ParentsMarketForChildren");
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first Parents Market Kids Perspective message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Marktstand",
                "Hola! Ich bin eine wandernde Haendlerin, die mit deinen Eltern gesprochen hat. Kann ich einen Marktstand bei dir in der Stadt eröffnen?",
                null, null, null, null, "Klar!",
                Var0RightButtonClick,
                MessageWindow.Character_options.Character_Female_Peasant_01,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        // Adding the second Parents Market Kids Perspective message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Markterkundung",
                "Willkommen auf dem Markt! Deine Eltern haben ein paar Angebote für dich, wenn du genug Sportmünzen gesammelt hast.",
                null, null, null, null, "Angebote ansehen",
                Var1RightButtonClick,
                MessageWindow.Character_options.Character_Female_Peasant_01,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }

    void AddHikingExergameMessage()
    {
        // Local function for the Var0 right button click action
        void Var0RightButtonClick()
        {
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.HikingHouse = 1; // Update the specific building status
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Local function for the Var1 right button click action
        void Var1RightButtonClick()
        {
            // Placeholder for any specific action related to continuing the hiking activity
            // For example, starting a mini-game or showing beautiful scenes of nature
            SceneManager.Load("HikkingStoryManager"); // Adjust the scene name as necessary
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.HikingExergame.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.HikingExergame.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first Hiking Exergame message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.HikingExergame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Wanderlust",
                "Grüße, Wanderlustige! Ich bin ein Barden, der die Geschichten der Berge in Liedern festhält. Darf ich mich in eurem Dorf niederlassen, um von hier aus meine Wanderungen zu starten?",
                null, null, null, null, "Klar!",
                Var0RightButtonClick,
                MessageWindow.Character_options.Character_Male_Baird,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        // Adding the second Hiking Exergame message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.HikingExergame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Bergesruf",
                "Willkommen zurück, Freund der Natur! Bist du bereit, mich auf meiner nächsten Expedition zu begleiten?",
                null, null, null, null, "Auf geht's!",
                Var1RightButtonClick,
                MessageWindow.Character_options.Character_Male_Baird,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }

    void AddWeedThePlantMessage()
    {
        // Local function for the Var0 right button click action
        void Var0RightButtonClick()
        {
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.WeedThePlantHouse = 1; // Update the specific building status
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Local function for the Var1 right button click action
        void Var1RightButtonClick()
        {
            // Placeholder for any specific action related to engaging in the weeding activity
            // For example, starting a mini-game or showing educational content about plants
            SceneManager.Load("WeedThePlant"); // Adjust the scene name as necessary
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.WeedThePlant.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.WeedThePlant.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first Weed The Plant message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.WeedThePlant.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Magischer Garten",
                "Guten Tag! Ich bin ein Zauberer mit einer Vorliebe für botanische Magie. Darf ich mich in eurem Dorf niederlassen und eure Gärten verzaubern?",
                null, null, null, null, "Klar!",
                Var0RightButtonClick,
                MessageWindow.Character_options.Character_Male_Wizard,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        // Adding the second Weed The Plant message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.WeedThePlant.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Unkrautzauberei",
                "Willkommen zurück! Bist du bereit, etwas über die Kunst der Unkrautentfernung durch Magie zu lernen?",
                null, null, null, null, "Auf geht's!",
                Var1RightButtonClick,
                MessageWindow.Character_options.Character_Male_Wizard,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }

    void AddFitnessBoxingMessage()
    {
        // Local function for the Var0 right button click action
        void Var0RightButtonClick()
        {
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.FitnessBoxingHouse = 1; // Update the specific building status
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Local function for the Var1 right button click action
        void Var1RightButtonClick()
        {
            // Placeholder for any specific action related to continuing the boxing session
            // For example, loading a boxing mini-game or refreshing the scene for another session
            SceneManager.Load("FitnessBoxing"); // Adjust the scene name as necessary
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first Fitness Boxing message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Boxtraining",
                "Links, Rechts, Ausweichen und Schlag! ... Huch! Ich habe dich gar nicht gesehen, ich trainiere gerade mein Boxen. Soll ich eine Weile bleiben und es dir beibringen?",
                null, null, null, null, "Klar!",
                Var0RightButtonClick,
                MessageWindow.Character_options.Character_Female_Queen,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        // Adding the second Fitness Boxing message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Boxrunde",
                "Da bist du ja wieder. Los geht's ans Boxen?",
                null, null, null, null, "Auf geht's!",
                Var1RightButtonClick,
                MessageWindow.Character_options.Character_Female_Queen,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }

   void AddDoodleJumpMessage()
    {
        // Local function for the Var0 right button click action
        void Var0RightButtonClick()
        {
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.DoodleJumpHouse = 1; // Update the specific building status
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Local function for the Var1 right button click action
        void Var1RightButtonClick()
        {
            // Placeholder for any specific action, such as launching an expedition or a mini-game
            // For demonstration, let's assume it's navigating or refreshing the current scene
            SceneManager.Load("DoodleJump"); // Adjust the scene name as necessary
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first Doodle Jump message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Expedition",
                "Hey! Ich habe gehört man kann im Himmel immer höher springen. Kann ich mich hier in der Stadt niederlassen, um eine Expedition zu starten?",
                null, null, null, null, "Klar!",
                Var0RightButtonClick,
                MessageWindow.Character_options.Character_Female_Peasant_02,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        // Adding the second Doodle Jump message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Zu den Wolken!",
                "Willkommen bei mir zuhause, sollen wir gleich mal los in die Wolken?",
                null, null, null, null, "Auf geht's!",
                Var1RightButtonClick,
                MessageWindow.Character_options.Character_Female_Peasant_02,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }

    void AddMountainClimberMessage()
    {
        // Local function for the first list entry action
        void Var0RightButtonClick()
        {
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.Climber = 1;
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Local function for the second list entry action
        void Var1RightButtonClick()
        {
            SceneManager.Load("TreeClimber");
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.MountainClimberExergame.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.MountainClimberExergame.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first Mountain Climber message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.MountainClimberExergame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Klettern",
                "Grüzi! Ich bin Heinrich. Ich wollte den Berg hier rauf aber brauche erstmal eine Pause. Kann ich hier übernachten?",
                null, null, null, null, "Klar!",
                Var0RightButtonClick, // Use Var0RightButtonClick for the action
                MessageWindow.Character_options.Character_Male_Sorcerer,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        // Adding the second Mountain Climber message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.MountainClimberExergame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Der Berg!",
                "Grüzi! Ich bin Heinrich und hänge ziemlich in den Seilen. Meinst du, du kannst für mich da hoch klettern?",
                "Später", messageWindow.DeactivateMessageWindow, "Klar!",
                Var1RightButtonClick, // Use Var1RightButtonClick for the action
                null, null,
                MessageWindow.Character_options.Character_Male_Sorcerer,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }

    void AddYouTubeSceneMessage()
    {
        // Local function for the first list entry action
        void BuildYouTubeBuildingRightButtonClick()
        {
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.YouTubeHouse = 1;
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Local function for the second list entry action
        void Var1RightButtonClick()
        {
            SceneManager.Load("Demo1.2 - Fullscreen");
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first YouTube Scene message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Filmpalast",
                "Schaust du auch so gerne Videos, wie ich? Ich habe gehört der König mag es auch? Ich kann gerne mit meinem Kino hierher ziehen!",
                null, null, null, null, "Klasse!",
                BuildYouTubeBuildingRightButtonClick, // Use BuildYouTubeBuildingRightButtonClick for the action
                MessageWindow.Character_options.Character_Female_Druid,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        // Adding the second YouTube Scene message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "YouTube",
                "Hey! Willkommen in unserem kleinen Kino. Möchtest du mit uns Sport treiben?",
                "Gerade nicht", messageWindow.DeactivateMessageWindow, "Klar!",
                Var1RightButtonClick, // Use Var1RightButtonClick for the action
                null, null,
                MessageWindow.Character_options.Character_Female_Witch,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }

    void AddObstacleRunningMessage()
    {
        // Local function for the first list entry action
        void Var0RightButtonClick()
        {
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.Witch = 1;
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Local function for the second list entry action
        void Var1RightButtonClick()
        {
            SceneManager.Load("ObstacleRunning_0");
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first Obstacle Running message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Im Walde",
                "Willkommen, willkommen! Ich heiße Esmeralda und würde gerne am Fest des Koenigs teilnehmen, um ihm ein ganz besonderes Getraenk zu geben! Dagegen kannst du doch nichts haben, oder?",
                null, null, null, null, "...?",
                Var0RightButtonClick, // Reference to the Var0RightButtonClick method
                MessageWindow.Character_options.Character_Female_Druid,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        // Adding the second Obstacle Running message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Der Berg!",
                "Hallo! Ich bereite gerade noch eine Kleinigkeit fur das Bankett des Koenigs vor. Willst du mein Kaninchen ein bisschen ausfuehren in der Zeit?",
                "Spaeter", messageWindow.DeactivateMessageWindow, "Klar!",
                Var1RightButtonClick, // Reference to the Var1RightButtonClick method
                null, null,
                MessageWindow.Character_options.Character_Female_Druid,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }

    void AddAsianMonkMessage()
    {
        // Function for the first list entry action
        void Var0RightButtonClick()
        {
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.Temple = 1;
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Function for the second list entry action
        void Var1RightButtonClick()
        {
            SceneManager.Load("AM-2D-Game");
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first Asian Monk message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Kung Fu!",
                "Oh ein Schmetterling! Schau mal! ... Hm, wo ich wohl heute schlafen soll. Kann ich in die Burg kommen? Ich bin Meister So Chill.",
                null, null, "Klar!",
                Var0RightButtonClick, // Use Var0 function for the first action
                null, null,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        // Adding the second Asian Monk message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Kung Fu!",
                "Willkommen in meinem Dojo. Moechtest du das Kaempfen lernen?",
                "Noch nicht", messageWindow.DeactivateMessageWindow, "Klar!",
                Var1RightButtonClick, // Use Var1 function for the second action
                null, null,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }

    void AddFarmMessage()
    {
        void Var0RightButtonClicked()
        {
            // Logic for what happens when the right button is clicked for the first farm message
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null)
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.Farm = 1;
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        // Ensure the list for this scene is initialized in the dictionary
        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the first farm message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Bauernhof",
                "Hey! Ich heiße Otto. Ich habe gehört der König will ein Fest feiern? Ich könnte mich um Essen kümmern, wenn ich eine Farm bauen darf?",
                "Bald",
                messageWindow.DeactivateMessageWindow,
                "Klar!",
                Var0RightButtonClicked, // Reference to the Var0RightButtonClicked method
                null, null,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        void Var1RightButtonClicked()
        {
            // Logic for what happens when the right button is clicked for the second farm message
            SceneManager.Load("Pet");
        }

        // Adding the second farm message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Bauernhof",
                "Willkommen auf dem Hof! Willst du zu deinem Haustier?",
                "Gerade nicht",
                messageWindow.DeactivateMessageWindow,
                "Klar!",
                Var1RightButtonClicked, // Reference to the Var1RightButtonClicked method
                null, null,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            )
        );
    }


    void AddStoneCutterMessage()
    {
        void Var0RightButtonClicked()
        {
            // Logic that will be executed when the right button is clicked
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null) 
            {
                builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
            }
            builtBuildings.Mining = 1;
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();
        }

        if (!messageLibrary.ContainsKey(SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString()))
        {
            messageLibrary.Add(SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString(), new List<MessageObjectBlueprint.messageObject>());
        }

        // Adding the message object
        messageLibrary[SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Mine",
                "Hallo! Ich bin Bergfrau. Ich habe gehört in den tiefen des Berges gibt es einen Drachen? Kann ich danach suchen? All das Gold und Silber, dass ich finde kannst du behalten, ich will den Drachen!",
                null, null, null, null,
                "Ok",
                Var0RightButtonClicked, // Reference to the right button clicked method
                MessageWindow.Character_options.Character_Female_Gypsy,
                AnimationLibrary.Animations.Talk,
                null
            )
        );

        void rightButtonClick()
        {
            SceneManager.Load("StoneCrushing");
        }

        messageLibrary[SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                "Der Berg!",
                "Oh hallo! Nein, ich habe den Drachen noch nicht gefunden aber jede Menge Steine. Meinst du, du koenntest sie zerschlagen?",
                "Spaeter", // Left button text
                messageWindow.DeactivateMessageWindow, // Action for the left button
                "Klar!", // Right button text
                rightButtonClick, // Action for the right button, using the newly defined method
                null, // Placeholder for parameters not provided
                null, // Placeholder for parameters not provided
                MessageWindow.Character_options.Character_Female_Gypsy, // Character option
                AnimationLibrary.Animations.Talk, // Animation
                null // Placeholder for the last parameter
            )
        );
    }

    void AddWoodCutterMessages()
    {
        // int = 0
        void Var0RightButtonClicked()
        {
            // loading in the existing BuiltBuildings-Block
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
            if (builtBuildings == null) { builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");}
            builtBuildings.WoodCutting = 1;
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
            messageWindow.DeactivateMessageWindow();

            Message_EventSystem.SendMessage(new MessageObjectBlueprint.messageObject(
                "Holzfaeller",
                "Danke, dass ich bleiben darf. Komm bald wieder damit wir Holz hacken koennen.",
                null,
                null,
                null,
                null,
                "Ok",
                messageWindow.DeactivateMessageWindow,
                MessageWindow.Character_options.Character_Female_Peasant_01,
                AnimationLibrary.Animations.Talk,
                null
            ));
        }

        messageLibrary.Add(
            SceneManagerStaticScript.AvailableScenes.WoodCuttingExergame.ToString(), 
            new List<MessageObjectBlueprint.messageObject> {
                new MessageObjectBlueprint.messageObject(
                        "Holzfaeller", 
                        "Howdy Partner! Ich heiße Marina und habe gehört der Koenig braucht Feuerholz für die Küche. Da er ja so viel isst, dachte ich mir, koennte ich ja hier fuer in arbeiten?", 
                        null, null, null, null, "Klar!", 
                        Var0RightButtonClicked, 
                        MessageWindow.Character_options.Character_Female_Peasant_01, 
                        AnimationLibrary.Animations.Talk, 
                        null
                )
            }
        );

        // int = 1
        void Var1RightButtonClicked()
        {
            SceneManager.Load("WoodChopping");
        }

        messageLibrary[SceneManagerStaticScript.AvailableScenes.WoodCuttingExergame.ToString()].Add(
            new MessageObjectBlueprint.messageObject(
                    "Der Berg!",
                    "Howdy! Ich habe mir leider einen Splitter eingefangen, meinst du, du kannst für mich heute Holzhacken?",
                    "Spaeter", // Left button text
                    messageWindow.DeactivateMessageWindow, // Action for the left button
                    "Klar!", // Right button text
                    Var1RightButtonClicked, // Action for the right button
                    null, // Placeholder for parameters not provided
                    null, // Placeholder for parameters not provided
                    MessageWindow.Character_options.Character_Female_Peasant_01, // Character option
                    AnimationLibrary.Animations.Talk, // Animation
                    null // Placeholder for the last parameter
            )
        );
    }
}
