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




public class SaveGameScript : MonoBehaviour
{
    List<MainSaveObject> mainSaveObjects = new();

    [Serializable]
    public class MainSaveObject
    {
        // empty mother class
    }

    [Serializable]
    public class GameData : MainSaveObject
    {
        public string s = "aaaaaa";
    }

    [Serializable]
    public class Game2 : MainSaveObject
    {
        public float f = 3.4f;
        public Quaternion q = new(1, 2, 3, 4);
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
            // We don't handle deserialization in this example.
            // Adjust if necessary for your use case.
            throw new NotImplementedException();
        }
    }

    void Start()
    {
        List<MainSaveObject> u = new();

        mainSaveObjects.Add(new GameData());
        u.Add(new GameData());
        u.Add(new GameData());
        u.Add(new Game2());
        u.Add(new Game2());
        u.Add(new Game2());

        //Debug.Log(JsonUtility.ToJson(u));


        // ----------------
        JsonListWrapper<MainSaveObject> wrapper = new JsonListWrapper<MainSaveObject> { items = u };

        // Serialize with Newtonsoft.Json and handle polymorphism
        string combinedJson = JsonConvert.SerializeObject(wrapper, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
            Converters = new List<JsonConverter> { new QuaternionConverter() }  // Use our custom Quaternion converter
        });


        Debug.Log(combinedJson);

    }

    // Declaration of variables
    private string savefile;
    void Awake()
    {
        savefile = Application.persistentDataPath + "/gamedata.json";
    }

    public void Save()
    {
        if (File.Exists(savefile))
        {
            File.Delete(savefile);
        }

        File.WriteAllText(savefile, Get_Save_Data());
    }

    private string Get_Save_Data()
    {
        return "NULL";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
