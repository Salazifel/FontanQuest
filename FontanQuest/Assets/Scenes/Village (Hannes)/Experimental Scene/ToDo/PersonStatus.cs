using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStatus : MonoBehaviour
{
    public bool busy;
}

/* System explained
 * each person has several scripts to them
 * 1. Person Status - a script with general variables such as busy
 * 2. a MoveTo script, allowing the person to move on the NavMesh
 * 3. Scripts for capabilities (e.g. Build, Collect, Work)
 */