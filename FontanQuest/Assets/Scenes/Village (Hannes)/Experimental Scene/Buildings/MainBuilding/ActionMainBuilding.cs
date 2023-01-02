using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMainBuilding : MonoBehaviour
{
    public GameObject MasterData;

    public int maxWood;
    public int maxStone;
    public int maxFood;
    // Start is called before the first frame update
    void Awake()
    {
        MasterData.GetComponent<Ressources>().IncreaseMaxRessources(maxFood, maxStone, maxFood);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
