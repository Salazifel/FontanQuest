using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameData
{
    public static bool FirstVisit = true;
    public static int ChoppingHighscore = 0;
    public static int StoneMiningHighscore = 0;

    public bool firstVisit;
    public int choppingHighscore;
    public int stoneMiningHighscore;
    public MiniGameData()
    {
        firstVisit = FirstVisit;
        choppingHighscore = ChoppingHighscore;
        stoneMiningHighscore = StoneMiningHighscore;
    }


    public static void NewWoodChoppingHighScore(int score)
    {
        if (score > ChoppingHighscore)
        {
            ChoppingHighscore = score;
            SaveGameData.Save();
        }

    }

    public static void NewStoneMiningHighScore(int score)
    {
        if (score > StoneMiningHighscore)
        {
            StoneMiningHighscore = score;
            SaveGameData.Save();
        }
    }
}


