using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStatus : MonoBehaviour
{
    public bool busy;
    public GameObject MasterData;
    public Material[] material;
    private Renderer rend;

    public void SetIdle()
    {
        busy = false;
        rend.sharedMaterial = material[0]; // change to red
        SendMessage("set_wander", true);
        // MasterData.SendMessage("CheckToDoList");
    }

    public void SetBusy()
    {
        busy = true;
        SendMessage("set_wander", false);
        rend.sharedMaterial = material[1]; // change to green
    }

    void Awake()
    {
        // tutorial for material change: https://www.youtube.com/watch?v=dJB07ZSiW7k
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
}

/* System explained
 * each person has several scripts to them
 * 1. Person Status - a script with general variables such as busy
 * 2. a MoveTo script, allowing the person to move on the NavMesh
 * 3. Scripts for capabilities (e.g. Build, Collect, Work)
 */