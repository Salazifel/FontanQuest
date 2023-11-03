using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveThisObject : MonoBehaviour
{
    public int primaryKey;

    public void saveMe(SaveGameObjects.MainSaveObject mainSaveObject, string saveFileName, int OverridePrimaryKey = 0)
    {
        primaryKey = SaveGameMechanic.saveSaveGameObject(mainSaveObject, saveFileName, OverridePrimaryKey);
    }

    public int getMyPrimaryKey() 
    {
        return primaryKey;
    }
}
