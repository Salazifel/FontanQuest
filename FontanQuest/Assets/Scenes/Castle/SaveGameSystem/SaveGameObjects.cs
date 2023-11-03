using System;
using UnityEngine;

public class SaveGameObjects : MonoBehaviour
{
    [Serializable]
    public class MainSaveObject
    {
        public int primaryKey;
        protected string GameSaveObjectType;
        string getGameSaveObjectType() {
            return GameSaveObjectType;
        }

        public virtual void Print()
        {
            Debug.Log(primaryKey);
        }
    }


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

    [Serializable]
    public class House : MainSaveObject
    {
        public float weardown;

        public override void Print()
        {
            Debug.Log(primaryKey + " wearDown: " + weardown.ToString());
        }
    }
}
