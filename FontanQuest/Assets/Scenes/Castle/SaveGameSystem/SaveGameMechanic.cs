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

    public static void cleanUpData()
    {
        
    }

    public static int saveSaveGameObject(SaveGameObjects.MainSaveObject mainSaveObject, string saveFileName, int OverridePrimaryKey = 0)
    {
        string filePath = savefilePath + "/" + saveFileName;
        EnsureFoldersExist(filePath);
        filePath = filePath + "/" + mainSaveObject.GetType() + ".json";

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
            // resetting the gameObject
            currentGameSaveData.gameSaveObjects.Clear();
            currentGameSaveData.primaryKey = 0;
        }

        if (OverridePrimaryKey > 0)
        { // an object has to be overwritten
          // Find the object with the specified primary key
            int index = currentGameSaveData.gameSaveObjects.FindIndex(obj => obj.primaryKey == OverridePrimaryKey);
            if (index >= 0) // If found
            {
                // Update/replace the object at the found index
                mainSaveObject.primaryKey = OverridePrimaryKey;
                currentGameSaveData.gameSaveObjects[index] = mainSaveObject;
            }
            else
            {
                Debug.LogWarning("No object found with the specified primary key. Adding the new object instead.");
                OverridePrimaryKey = 0;
            }
        }

        // checking again, as it might have changed when trying to override an object
        if (OverridePrimaryKey == 0)
        {
            // adding a new object
            currentGameSaveData.primaryKey++;
            mainSaveObject.primaryKey = currentGameSaveData.primaryKey;
            currentGameSaveData.gameSaveObjects.Add(mainSaveObject);
        }

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

        // return primary key to be saved on the object
        return mainSaveObject.primaryKey;
    }

    public static SaveGameObjects.MainSaveObject getSaveGameObject(int primaryKey)
    {
        return currentGameSaveData.gameSaveObjects.FirstOrDefault(obj => obj.primaryKey == primaryKey);
    }

    public static void deleteSaveGameObject(SaveGameObjects.MainSaveObject emptyMainSaveObject, string saveFileName, int primaryKey)
    {

        string filePath = savefilePath + "/" + saveFileName;
        filePath = filePath + "/" + emptyMainSaveObject.GetType() + ".json";

        // Load existing objects from file
        if (File.Exists(filePath))
        {
            try
            {
                Load(File.ReadAllText(filePath));
            }
            catch (Exception e)
            {
                Debug.Log("Save File corrupted: " + saveFileName);
                return; // Exit if there's an error reading the file
            }
        }
        else
        {
            Debug.LogWarning("File not found: " + filePath);
            return;
        }

        // Find and remove the object with the specified primary key
        int index = currentGameSaveData.gameSaveObjects.FindIndex(obj => obj.primaryKey == primaryKey);
        if (index >= 0)
        {
            currentGameSaveData.gameSaveObjects[index].deleted = true;

            // Serialize with Newtonsoft.Json and handle polymorphism
            string combinedJson = JsonConvert.SerializeObject(currentGameSaveData, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                Converters = new List<JsonConverter> { new QuaternionConverter() }  // Use custom Quaternion converter
            });

            // Save the modified data back to file
            File.WriteAllText(filePath, combinedJson);
        }
        else
        {
            Debug.LogWarning("Object with the primary key " + primaryKey + " not found!");
        }
    }


    public static void Load(string json)
    {
        currentGameSaveData = new GameSaveData();

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
