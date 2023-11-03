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
    public class GameData : MainSaveObject
    {
        public int coins;

        public GameData() {
            GameSaveObjectType = "gameData";
        }

        public override void Print()
        {
            Debug.Log(primaryKey + " coins: " + coins.ToString());
        }
    }
}
