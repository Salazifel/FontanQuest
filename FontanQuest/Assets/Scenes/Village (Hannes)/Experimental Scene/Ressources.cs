using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ressources : MonoBehaviour
{
    // variables storing the player's ressources
    public int wood;
    public int stone;
    public int food;
    public int gold;

    // labels to display the player's ressources
    private TextMeshProUGUI WoodText;
    private TextMeshProUGUI StoneText;
    private TextMeshProUGUI FoodText;
    private TextMeshProUGUI GoldText;

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

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Menubuttons").SetActive(false);

        WoodText = GameObject.Find("Wood").GetComponent<TextMeshProUGUI>();
        StoneText = GameObject.Find("Stone").GetComponent<TextMeshProUGUI>();
        FoodText = GameObject.Find("Food").GetComponent<TextMeshProUGUI>();
        GoldText = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        WoodText.text = wood.ToString();
        StoneText.text = stone.ToString();
        FoodText.text = food.ToString();
        GoldText.text = gold.ToString();
    }
}

