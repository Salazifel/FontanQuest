using System;
using UnityEngine;

public class SaveGameObjects : MonoBehaviour
{

    // ----------------------- DO NOT CHANGE ----------------------------
    [Serializable]
    public class MainSaveObject
    {
        public int primaryKey;
        public bool deleted = false;
        protected string GameSaveObjectType;
        string getGameSaveObjectType() {
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



        public GameData(int _coins) {
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
}
