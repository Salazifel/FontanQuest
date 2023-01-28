using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MedalManager : MonoBehaviour
{
    public Sprite Level0Image;
    public Sprite Level1Image;
    public Sprite Level2Image;
    public Sprite Level3Image;
    public Sprite Level4Image;


    public Medal ChoppingHighScore;
    // Start is called before the first frame update
    void Start()
    {
        ChoppingHighScore.Manager = this;
        ChoppingHighScore.Value = 10;// MiniGameData.ChoppingHighscore;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
