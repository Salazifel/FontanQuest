using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveThisObject : MonoBehaviour
{
    // -------------------------- ADD THIS CLASS TO AN OBJECT THAT YOU WANT TO BE SAVED
    public int primaryKey;
    public string MySaveFileName;
    SaveGameObjects.MainSaveObject MyMainSaveObject;

    public void saveMe(SaveGameObjects.MainSaveObject mainSaveObject, string saveFileName, int OverridePrimaryKey = 0)
    {
        MySaveFileName = saveFileName;
        MyMainSaveObject = mainSaveObject;
        primaryKey = SaveGameMechanic.saveSaveGameObject(mainSaveObject, saveFileName, OverridePrimaryKey);
    }

    public int getMyPrimaryKey() 
    {
        return primaryKey;
    }

    public void deleteMe() {
        SaveGameMechanic.deleteSaveGameObject(MyMainSaveObject, MySaveFileName, getMyPrimaryKey());
    }
}
