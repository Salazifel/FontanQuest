using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingMaster : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI WoodText;
    private TextMeshProUGUI StoneText;
    private TextMeshProUGUI FoodText;
    private TextMeshProUGUI GoldText;
    void Awake()
    {
         GameObject.FindGameObjectWithTag("Menubuttons").SetActive(false);

         WoodText = GameObject.Find("Wood").GetComponent <TextMeshProUGUI>();
         StoneText = GameObject.Find("Stone").GetComponent<TextMeshProUGUI>();
         FoodText = GameObject.Find("Food").GetComponent<TextMeshProUGUI>();
         GoldText = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WoodText.text = GetComponent<Ressources>().wood.ToString();
        StoneText.text = GetComponent<Ressources>().stone.ToString();
        FoodText.text = GetComponent<Ressources>().food.ToString();
        GoldText.text = GetComponent<Ressources>().gold.ToString();
    }
}
