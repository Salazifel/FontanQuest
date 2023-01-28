using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Medal : MonoBehaviour
{


    public string Title;

    public int Level1;
    public int Level2;
    public int Level3;
    public int Level4;
    public int Value
    {
        get { return value; }
        set
        {
            this.value = value;
            int xpToNextLevel = 0;
            Sprite image = null;

            if (value < Level1)
            {
                xpToNextLevel = Level1;
                image = Manager.Level0Image;

            }
            else if (value < Level2)
            {
                xpToNextLevel = Level2;
                image = Manager.Level1Image;
            }
            else if (value < Level3)
            {
                xpToNextLevel = Level3;
                image = Manager.Level2Image;
            }
            else if (value <= Level4)
            {
                xpToNextLevel = Level4;
                image = Manager.Level3Image;
            }
            else
            {
                xpToNextLevel = Level4;
                image = Manager.Level4Image;
                ProgressUi.value = Level4;
            }
            // set all components according to level and value
            _valueText.text = value.ToString();
            _nextLevelValueText.text = xpToNextLevel.ToString();
            ProgressUi.value = value;
            ProgressUi.maxValue = xpToNextLevel;
            Image.sprite = image;
        }
    }
    private int value = 0;
    
    public MedalManager Manager;

    private TextMeshProUGUI _titleUi;
    private TextMeshProUGUI _valueText;
    private TextMeshProUGUI _nextLevelValueText;

    private Slider ProgressUi;
    private UnityEngine.UI.Image Image;

    // Start is called before the first frame update
    void Start()
    {
        _titleUi = this.gameObject.transform.Find("Title").gameObject.GetComponent<TextMeshProUGUI>();
        _titleUi.text = Title;
        ProgressUi = this.gameObject.transform.Find("Progress").gameObject.GetComponent<Slider>();
        _nextLevelValueText = ProgressUi.transform.Find("NextLevelText").gameObject.GetComponent<TextMeshProUGUI>();
        _valueText = ProgressUi.transform.Find("ValueText").gameObject.GetComponent<TextMeshProUGUI>();
        Image = this.gameObject.gameObject.GetComponent<UnityEngine.UI.Image>();
        Manager = GetComponent<MedalManager>();
    }
}
