using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Medal : MonoBehaviour
{
    public string Title;
    public int Value=0;
    private int Level1;
    private int Level2;
    private int Level3;

    private TextMeshProUGUI TitleUi;
    private Slider ProgressUi;
    private GameObject MedalObject;
    // Start is called before the first frame update
    void Start()
    {
        TitleUi = this.gameObject.transform.Find("Title").gameObject.GetComponent<TextMeshProUGUI>();
        ProgressUi = this.gameObject.transform.Find("HowFarToNextMedal").gameObject.GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
