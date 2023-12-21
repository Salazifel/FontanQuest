using System;
using UnityEngine;

public class SaveGameObjects : MonoBehaviour
{

    // ----------------- HOW TO SAVE & LOAD & DELETE --------------------

    /*
    // LOADING (you could also load all objects of that type)
    SaveGameObjects.TreeClimber treeClimber = (SaveGameObjects.TreeClimber) SaveGameMechanic.getSaveGameObjectByPrimaryKey(new SaveGameObjects.TreeClimber(1), "treeClimber", 1);
    // SAVING (this is for one object, you can also use something like SELECT ALL)
    SaveGameMechanic.getSaveGameObjectByPrimaryKey(treeClimber, "treeClimber", 1);
    // DELETING (you could also delete all objects of that type or the folder)
    SaveGameMechanic.deleteSaveGameObject(new SaveGameObjects.TreeClimber(1), "treeClimber", 1);
    */

    // ----------------------- DO NOT CHANGE ----------------------------
    [Serializable]
    public class MainSaveObject
    {
        public int primaryKey;
        public bool deleted = false;
        protected string GameSaveObjectType;
        string getGameSaveObjectType()
        {
            return GameSaveObjectType;
        }

        public virtual void Print()
        {
            Debug.Log(primaryKey);
        }
    }

    // --------------------- INPUT NEW OBJECT HERE ----------------------

    /*                             STRUCTURE

    [Serializable]

    public class NAME : MainSaveObject // or branching down further
    {
        // variables

        public override void Print() 
        {
            // best to redifine it for debugging purposes
        }
    }

    */

    [Serializable]

    public class JumpingTheRopeSavingGame : MainSaveObject
    {
        public int howmanyjumps;
        public float glee;

        public override void Print()
        {
            Debug.Log(howmanyjumps.ToString() + " " + glee.ToString());
        }
    }


    [Serializable]
    public class GameData : MainSaveObject
    {
        public int coins;
        public int daysPlayed;
        public string nameOfPlayer;

        public GameData(int _coins)
        {
            GameSaveObjectType = "gameData";
            coins = _coins;
        }

        public override void Print()
        {
            Debug.Log(primaryKey + " coins: " + coins.ToString());
        }
    }

    [Serializable]
    public class BuiltBuildings : MainSaveObject
    {
        public Boolean CityWalls;
        public Boolean Castle;
        public Boolean Temple;
        public Boolean Stables;

        public BuiltBuildings(Boolean CityWallsActive, Boolean CastleActive, Boolean TempleActive, Boolean StablesActive)
        {
            GameSaveObjectType = "BuiltBuildings";
            CityWalls = CityWallsActive;
            Castle = CastleActive;
            Temple = TempleActive;
            Stables = StablesActive;
        }

        public override void Print()
        {
            Debug.Log(primaryKey + " CityWalls" + CityWalls.ToString());
        }
    }

    [Serializable]

    public class TreeClimber : MainSaveObject
    {
        public int highscore;

        public TreeClimber(int _highscore)
        {
            highscore = _highscore;
        }

        public override void Print()
        {
            base.Print();
            Debug.Log(highscore.ToString());
        }
    }

    [Serializable]
    public class AsianMonkSavingGame : MainSaveObject
    {
        public int currentLevel;

        public AsianMonkSavingGame(int _currentLevel)
        {
            currentLevel = _currentLevel;
            GameSaveObjectType = "AsianMonkSavingGame";
        }

        public override void Print()
        {
            Debug.Log(primaryKey + " level: " + currentLevel.ToString());
        }
    }


    [Serializable]

    public class FitnessBoxingSavingGame : MainSaveObject
    {
        public int currentLevel;

        public FitnessBoxingSavingGame(int _currentLevel)
        {
            currentLevel = _currentLevel;
            GameSaveObjectType = "FitnessBoxingSavingGame";
        }

        public override void Print()
        {
            Debug.Log(primaryKey + " level: " + currentLevel.ToString());
        }
    }

    [Serializable]

    public class AvatarSystem : MainSaveObject
    {
        public Boolean onBoardingDone;

        public AvatarSystem(Boolean _onBoardingDone)
        {
            onBoardingDone = _onBoardingDone;
        }

        public override void Print()
        {
            base.Print();
        }
    }

    [Serializable]

    public class PetSystem : MainSaveObject
    {
        public Boolean onBoardingDone;
        public Boolean animalSelected;
        public string selectedAnimal;

        public PetSystem(Boolean _onBoardingDone, Boolean _animalSelected)
        {
            onBoardingDone = _onBoardingDone;
            animalSelected = _animalSelected;
            // selectedAnimal = _selectedAnimal;
        }

        public override void Print()
        {
            base.Print();
            Debug.Log(onBoardingDone);
        }
    }

    [Serializable]

    public class CastleOnBoardingSystem: MainSaveObject
    {
        public Boolean onBoardingDone;

        public CastleOnBoardingSystem (Boolean _onBoardingDone)
        {
            onBoardingDone = _onBoardingDone;
        }
    }
}
