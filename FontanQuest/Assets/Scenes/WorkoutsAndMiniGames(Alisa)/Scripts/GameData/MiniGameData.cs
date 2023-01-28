using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameData
{
    public static bool FirstVisit = true;
    public static int ChoppingHighscore = 0;
    public static int StoneMiningHighscore = 0;
    public static int PlayedChoppingGameXTimes = 0;
    public static int PlayedMiningGameXTimes = 0;
    public static int CompletedFindTheCureLevel1XTimes = 0;
    public static int CompletedFindTheCureLevel2XTimes = 0;
    public static int CompletedFindTheCureLevel3XTimes = 0;


    public bool firstVisit;
    public int choppingHighscore;
    public int stoneMiningHighscore;
    public int playedChoppingGameXTimes = 0;
    public int playedMiningGameXTimes = 0;
    public int completedFindTheCureLevel1XTimes = 0;
    public int completedFindTheCureLevel2XTimes = 0;
    public int completedFindTheCureLevel3XTimes = 0;
    public MiniGameData()
    {
        firstVisit = FirstVisit;
        choppingHighscore = ChoppingHighscore;
        stoneMiningHighscore = StoneMiningHighscore;
        playedChoppingGameXTimes = PlayedChoppingGameXTimes;
        playedMiningGameXTimes = PlayedMiningGameXTimes;
        completedFindTheCureLevel1XTimes = CompletedFindTheCureLevel1XTimes;
        completedFindTheCureLevel2XTimes = CompletedFindTheCureLevel2XTimes;
        completedFindTheCureLevel3XTimes = CompletedFindTheCureLevel3XTimes;
    }


    public static void NewWoodChoppingHighScore(int score)
    {
        if (score > ChoppingHighscore)
        {
            ChoppingHighscore = score;
            PlayedChoppingGameXTimes++;
            SaveGameData.Save();
        }
    }

    public static void NewStoneMiningHighScore(int score)
    {
        if (score > StoneMiningHighscore)
        {
            StoneMiningHighscore = score;
            PlayedChoppingGameXTimes++;
            SaveGameData.Save();
        }
    }

    public static void CompletedFindTheCure(int level)
    {
        switch (level)
        {
            case 1:
                CompletedFindTheCureLevel1XTimes++;
                return;
            case 2:
                CompletedFindTheCureLevel2XTimes++;
                return;
            case 3:
                CompletedFindTheCureLevel3XTimes++;
                return;
            default:
                return;
        }
    }
}


