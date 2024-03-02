using System;
using System.Collections.Generic;
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

    // ----------------------- CHANGE THIS ----------------------------

    /*
                               Instruction

        Add a case to the function below, if there is a new SaveGameObject.
        The case should simply initialize a new SaveGameObject.                                

    */
    public static MainSaveObject CreateSaveGameObject(string type)
    {
        switch (type)
        {
            case "JumpingTheRopeSavingGame":
                return new JumpingTheRopeSavingGame();
            case "GameData":
                return new GameData(0);
            case "BuiltBuildings":
                return new BuiltBuildings();
            case "AvatarSystem":
                return new AvatarSystem(false);
            case "TreeClimber":
                return new TreeClimber(0);
            case "AsianMonkSavingGame":
                return new AsianMonkSavingGame(0);
            case "FitnessBoxingSavingGame":
                return new FitnessBoxingSavingGame(0);
            case "WeedThePlantSavingGame":
                return new WeedThePlantSavingGame(0);
            case "PetSystem":
                return new PetSystem();
            case "CastleOnBoardingSystem":
                return new CastleOnBoardingSystem(false);
            case "YouTubeData":
                return new YouTubeData();
            case "DayActivity":
                return new DayActivity(new DateTime());
            case "MarketOffer":
                return new MarketOffer(null, null, 0, 0);
            case "ParentsOnboarding":
                return new ParentsOnboarding("", "");
            default:
                throw new ArgumentException("Unknown SaveGameObject. Please declare the initialization of an empty SaveGameObject above as a new case.");
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
    public class SportLog : MainSaveObject
    {
        public DateTime dateTime;
        public int HR_average;
        public int HR_min;
        public int HR_max;

        public SportLog(DateTime _dateTime, int _HR_average, int _HR_min, int _HR_max)
        {
            dateTime = _dateTime;
            HR_average = _HR_average;
            HR_min = _HR_min;
            HR_max = _HR_max;
        }
    }

    [Serializable]

    public class DayActivity : MainSaveObject
    {
        public DateTime dateTime;

        // string: name of the exercise
        // int: time in minutes of the exercise (how long the exercise is supposed to last)
        // bool: whether they have done the exercsie
        public List<Tuple<string, int, int>> exercises;

        public DayActivity(DateTime _datetime)
        {
            dateTime = _datetime;
            exercises = new List<Tuple<string, int, int>>();
        }

        public void AddExercise(string ExerciseEnumStringValue, int minutesOfExercise = 0)
        {
            Tuple<string, int, int> tuple = new Tuple<string, int, int> (ExerciseEnumStringValue, minutesOfExercise, 0);
            exercises.Add(tuple);
        }
    }

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
        public int numOfHay;
        public DateTime firstDayOfPlaying; // save the first time 2DOs
        public DateTime currentDebugTime;
        public Boolean parentMarketActivated;

        public GameData(int _coins)
        {
            GameSaveObjectType = "gameData";
            coins = _coins;
            firstDayOfPlaying = System.DateTime.Now;
            currentDebugTime = DateTime.Today;
            parentMarketActivated = true;
        }

        public override void Print()
        {
            Debug.Log(primaryKey + " coins: " + coins.ToString());
        }
    }

    [Serializable]
    public class BuiltBuildings : MainSaveObject
    {
        // 0 not yet built
        // 1 built
        // 2 other message type, but is built 
        public int CityWalls;
        public int Castle;
        public int Temple;
        public int Farm;
        public int YouTubeHouse;
        public int Witch;
        public int WoodCutting;
        public int Climber;
        public int Mining;
        public int DoodleJumpHouse;
        public int FitnessBoxingHouse;
        public int WeedThePlantHouse;
        public int HikingHouse;
        public int Market;

        public BuiltBuildings()
        {
            CityWalls = 0;
            Castle = 0;
            Temple = 0;
            Farm = 0;
            YouTubeHouse = 0;
            Witch = 0;
            WoodCutting = 0;
            Climber = 0;
            Mining = 0;
            DoodleJumpHouse = 0;
            FitnessBoxingHouse = 0;
            WeedThePlantHouse = 0;
            HikingHouse = 0;
            Market = 0;
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
    public class WeedThePlantSavingGame : MainSaveObject
    {
        public int currentLevel;
        public WeedThePlantSavingGame(int _currentLevel)
        {
            currentLevel = _currentLevel;
            GameSaveObjectType = "WeedThePlantSavingGame";
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
        public Boolean Fuettern_onBoardingDone;
        public Boolean Kuemmern_onBoardingDone;
        public float petScaleX;
        public float petScaleY;
        public float petScaleZ;
        public int Pet_Happiness;
        public int Pet_Cleanliness;
        public int Pet_Hunger;
        public float score_running;
        public DateTime lastLog_Fuettern;
        public DateTime lastLog_Putzen;
        public DateTime lastLog_Spielen;
        // public Vector3 currentScale;
        //onboarding for the rest of the games will be implemented
        // public Boolean Fuettern_onBoardingDone;
        // public Boolean Fuettern_onBoardingDone;
        public Boolean animalSelected;
        public string selectedAnimal;

        public Boolean selectionComplete;
        public Boolean gameSelected;


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
        public Boolean onBoardingVideoWatched;

        public CastleOnBoardingSystem (Boolean _onBoardingDone)
        {
            onBoardingDone = _onBoardingDone;
            onBoardingVideoWatched = false;
        }
    }

    [Serializable]
    public class YouTubeData : MainSaveObject
    {
        public string videoToBePlayed;

        public YouTubeData()
        {
            videoToBePlayed = null;
        }
    }

    [Serializable]
    public class MarketOffer : MainSaveObject
    {
        public static string nameOfOffer;
        public static string pathToIcon;
        public static int costOfOffer;
        public static int numOfAvailableTokens;

        public MarketOffer(string _nameOfOffer, string _pathToIcon, int _costOfOffer, int _numOfAvailableTokens)
        {
            nameOfOffer = _nameOfOffer;
            pathToIcon = _pathToIcon;
            costOfOffer = _costOfOffer;
            numOfAvailableTokens = _numOfAvailableTokens;
        }
    }

    [Serializable]
    public class ParentsOnboarding : MainSaveObject
    {
        public string nameParent;
        public string nameChild;

        public ParentsOnboarding(string _nameParent, string _nameChild)
        {
            nameParent = _nameParent;
            nameChild = _nameChild;
        }
        public override void Print()
        {
            Debug.Log("Parent's Name: " + nameParent + ", Child's Name: " + nameChild);
        }
    }
}
