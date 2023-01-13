using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayBuildingPrices : MonoBehaviour
{

    private GameObject MasterData;
    // Start is called before the first frame update

    void Start()
    {
        MasterData = GameObject.Find("MasterData");
    }
    public void DisplayBuildPrices(string category)
    {
        if (category == "ResourcesBuildingsBtns")
        {
            DisplayHelper("WoodCutter");
            DisplayHelper("StoneMine");
            DisplayHelper("Farm");
        }

        if (category == "PeopleBuildingsBtns")
        {
            DisplayHelper("House");
            DisplayHelper("Tavern");
        }

        if (category == "MainBuildingBtns")
        {
            DisplayHelper("MainBuilding");
            DisplayHelper("Stables");
        }
    }

    void DisplayHelper(string ObjectType)
    {
        Debug.Log(ObjectType);
        TextMeshProUGUI WoodPrice = GameObject.Find(ObjectType + "WoodResource").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI StonePrice = GameObject.Find(ObjectType + "StoneResource").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI GoldPrice = GameObject.Find(ObjectType + "GoldResource").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI UpKeepPrice = GameObject.Find(ObjectType + "UpKeepResource").GetComponent<TextMeshProUGUI>();

        string[] prices = MasterData.GetComponent<Prices>().ReturnPrice(ObjectType, 1);
        string[] upkeep = MasterData.GetComponent<Prices>().ReturnUpkeep(ObjectType, 1);

        WoodPrice.text = prices[0];
        StonePrice.text = prices[1];
        // food price skipped for now
        GoldPrice.text = prices[3];
        UpKeepPrice.text = upkeep[1];
    }
}
