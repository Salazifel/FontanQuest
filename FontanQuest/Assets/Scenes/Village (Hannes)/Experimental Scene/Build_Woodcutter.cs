using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_Woodcutter : MonoBehaviour
{
    public GameObject barracks_blueprint;
    public GameObject MasterData;

    public int wood;
    public int stone;
    public int food;
    public int gold;

    public void spawn_barracks_blueprint()
    {
        if (MasterData.GetComponent<Ressources>().CheckRessources(wood, stone, food, gold) == true)
        {
            Instantiate(barracks_blueprint);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(barracks_blueprint);
        }
    }

    public void Finalize_built()
    {
        MasterData.GetComponent<Ressources>().ChangeRessources(-wood, -stone, -food, -gold);
    }

    public void SendToDo()
    {
        
// MasterData.GetComponent<ToDoList>().IncomingToDo();
    }
}
