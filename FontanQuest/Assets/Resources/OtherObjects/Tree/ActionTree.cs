using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTree : MonoBehaviour
{
    void Start()
    {
        SendMessage("set_ObjectType", "Tree");
        SendMessage("set_Status", "null");
        SendMessage("set_ObjectFolder", "Tree");
    }
}
