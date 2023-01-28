using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ressources : MonoBehaviour
{
    // labels to display the player's ressources
    private TextMeshProUGUI WoodText;
    private TextMeshProUGUI StoneText;
    private TextMeshProUGUI FoodText;
    private TextMeshProUGUI GoldText;


    private TextMeshProUGUI WoodMax;
    private TextMeshProUGUI StoneMax;
    private TextMeshProUGUI FoodMax;

    void Awake()
    {
        // GameObject.FindGameObjectWithTag("Menubuttons").SetActive(false);

        WoodText = GameObject.Find("Wood Text (TMP)").GetComponent<TextMeshProUGUI>();
        StoneText = GameObject.Find("Stone Text (TMP) ").GetComponent<TextMeshProUGUI>();
        FoodText = GameObject.Find("Food Text (TMP) ").GetComponent<TextMeshProUGUI>();
        GoldText = GameObject.Find("Gold Text (TMP) ").GetComponent<TextMeshProUGUI>();

        // max resource displays

        WoodMax = GameObject.Find("Wood Max").GetComponent<TextMeshProUGUI>();
        StoneMax = GameObject.Find("Stone Max").GetComponent<TextMeshProUGUI>();
        FoodMax = GameObject.Find("Food Max").GetComponent<TextMeshProUGUI>();

        ResourceContainer.setInitialMax();
        ResourceContainer.TestResources();
    }

    void Start()
    {
        // run the load game function from SavingGameData.cs
        this.GetComponent<SavingGameData>().load_Game();
    }

    void LateUpdate()
    {
        // get current ressources from ResourceContainer.cs
        int[] res = ResourceContainer.getRes();
        int[] maxRes = ResourceContainer.getMaxRes();

        // set ressources to maximum
        if (res[0] > maxRes[0])
            res[0] = maxRes[0];
        if (res[1] > maxRes[1])
            res[1] = maxRes[1];
        if (res[2] > maxRes[2])
            res[2] = maxRes[2];

        ResourceContainer.setRes(res[0], res[1], res[2], res[3]);

        // display ressources
        WoodText.text = res[0].ToString();
        StoneText.text = res[1].ToString();
        FoodText.text = res[2].ToString();
        GoldText.text = res[3].ToString();

        // display max ressources
        WoodMax.text = "/ " + maxRes[0].ToString();
        StoneMax.text = "/ " + maxRes[1].ToString();    
        FoodMax.text = "/ " + maxRes[2].ToString();
    }
}

