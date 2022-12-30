using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherObjectsDataSys : MonoBehaviour
{
    public string BuildingType;
    public string status;

    public void set_ObjectType(string bType)
    {
        BuildingType = bType;
    }

    public void set_Status(string s)
    {
        status = s;
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
