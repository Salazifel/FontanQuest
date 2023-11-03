using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Unity.VisualScripting;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;


public class SaveGameMechanic : MonoBehaviour
{
    private static GameSaveData currentGameSaveData = new GameSaveData()
    {
        primaryKey = 0,
        gameSaveObjects = new List<SaveGameObjects.MainSaveObject>()
    };

    private static string savefilePath = Application.persistentDataPath;

    private static string savefile;

    public static string getSaveFileString()
    {
        return savefile;
    }

    public static void saveSaveGameObject(SaveGameObjects.MainSaveObject mainSaveObject, string saveFileName)
    {
        string filePath = savefilePath + "/" + saveFileName;
        EnsureFoldersExist(filePath);
        filePath = filePath + mainSaveObject.GetType() + ".json";

        if (File.Exists(filePath))
        {
            try
            {
                Load(File.ReadAllText(filePath));
            }
            catch (Exception e)
            {
                Debug.Log("Save File corrupted: " + saveFileName);
            }
        }
        else
        {
            currentGameSaveData.gameSaveObjects.Clear();
        }

        // Increment primaryKey for the new object
        currentGameSaveData.primaryKey++;

        // adding the new object
        mainSaveObject.primaryKey = currentGameSaveData.primaryKey; // assign the new primary key
        currentGameSaveData.gameSaveObjects.Add(mainSaveObject);

        // Serialize with Newtonsoft.Json and handle polymorphism
        string combinedJson = JsonConvert.SerializeObject(currentGameSaveData, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
            Converters = new List<JsonConverter> { new QuaternionConverter() }  // Use our custom Quaternion converter
        });

        Debug.Log(combinedJson);
        // Save the file
        File.WriteAllText(filePath, combinedJson);
    }

    public static SaveGameObjects.MainSaveObject getSaveGameObject(int primaryKey)
    {
        return currentGameSaveData.gameSaveObjects.FirstOrDefault(obj => obj.primaryKey == primaryKey);
    }

    void deleteSaveGameObject(string primaryKey)
    {

    }

    public static void Load(string json)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto, // Handle type names during deserialization
            Converters = new List<JsonConverter> { new QuaternionConverter() } // Use our custom Quaternion converter
        };

        currentGameSaveData = JsonConvert.DeserializeObject<GameSaveData>(json, settings);
    }

    // backend functions

    public static void EnsureFoldersExist(string folderPath)
    {
        // Check if directory exists
        if (!Directory.Exists(folderPath))
        {
            // If it doesn't, create it
            Directory.CreateDirectory(folderPath);
        }
    }

    [System.Serializable]
    public class JsonListWrapper<T>
    {
        public List<T> items = new List<T>();
    }
    public class QuaternionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Quaternion);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Quaternion quaternion = (Quaternion)value;
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            writer.WriteValue(quaternion.x);
            writer.WritePropertyName("y");
            writer.WriteValue(quaternion.y);
            writer.WritePropertyName("z");
            writer.WriteValue(quaternion.z);
            writer.WritePropertyName("w");
            writer.WriteValue(quaternion.w);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        [Serializable]
        public class GameSaveData
        {
            public int primaryKey;
            public List<SaveGameObjects.MainSaveObject> gameSaveObjects;
        }
    }

    [Serializable]
    public class GameSaveData
    {
        public int primaryKey;
        public List<SaveGameObjects.MainSaveObject> gameSaveObjects;
    }


    /*
    void Start()
    {
        List<SaveGameObjects.MainSaveObject> u = new();

        //Debug.Log(JsonUtility.ToJson(u));


        // ----------------
        JsonListWrapper<SaveGameObjects.MainSaveObject> wrapper = new JsonListWrapper<SaveGameObjects.MainSaveObject> { items = u };

        // Serialize with Newtonsoft.Json and handle polymorphism
        string combinedJson = JsonConvert.SerializeObject(wrapper, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
            Converters = new List<JsonConverter> { new QuaternionConverter() }  // Use our custom Quaternion converter
        });


        Debug.Log(combinedJson);

    } */
}
