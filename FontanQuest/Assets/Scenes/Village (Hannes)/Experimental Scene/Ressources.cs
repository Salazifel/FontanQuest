using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{
    public int wood;
    public int stone;
    public int food;
    public int gold;
    // Start is called before the first frame update
    public bool CheckRessources(int woodc, int stonec, int foodc, int goldc)
    {
        bool affordable = true;

        if (woodc > wood)
            { affordable = false; }
        if (stonec > stone)
            { affordable = false; }
        if (foodc > food)
            { affordable = false; }
        if (goldc > gold)
            { affordable = false; }

        return affordable;
    }

    public void ChangeRessources(int woodc, int stonec, int foodc, int goldc)
    {
        wood = wood + woodc;
        stone = stone + stonec;
        food = food + foodc;
        gold = gold + goldc;
    }
}

