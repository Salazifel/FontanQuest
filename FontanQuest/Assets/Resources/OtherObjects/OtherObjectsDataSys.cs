using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherObjectsDataSys : MonoBehaviour
{
    public string BuildingType;
    public string ObjectFolder;
    public string status;

    public void set_ObjectType(string bType)
    {
        BuildingType = bType;
    }

    public void set_Status(string s)
    {
        status = s;
    }

    public void set_ObjectFolder(string oF)
    {
        ObjectFolder = oF;
    }

    public string get_ObjectFolder()
    {
        return ObjectFolder;
    }

    public string get_ObjectType()
    {
        return BuildingType;
    }

    public string get_Status()
    {
        return status;
    }
}
