using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameAwakeScript : MonoBehaviour
{
    void Awake() {
        SaveGameMechanic.CleanUpSaveFiles();
    }
}

