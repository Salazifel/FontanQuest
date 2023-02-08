using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// stores the minigame data
/// Adding a new minigam feature which need to be stored
/// 1. add a public static variable for the feature
/// 2. add a public variable for the same feature
/// 3. add that the class variable is initilized with the static variable in the standard  consturcter MiniGameData()
/// 4. add that the static variable is set to the variable in the UpdateGameData()
/// 
/// Attention: if you want to change the feature you want to store, use always the static variabl!!! 
/// </summary>
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
   
    /// <summary>
    /// creates a minigameData object which has all properties set to the static members
    /// </summary>
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

    /// <summary>
    /// is called when the game starts and it loads the old game data
    /// it sets all static variables to the values of the loaded gameData
    /// </summary>
    /// <param name="gameData"></param>
    public static void UpdateGamedate (MiniGameData gameData)
    {
        MiniGameData.FirstVisit = gameData.firstVisit;
        MiniGameData.ChoppingHighscore = gameData.choppingHighscore;
        MiniGameData.StoneMiningHighscore = gameData.stoneMiningHighscore;
        MiniGameData.PlayedChoppingGameXTimes = gameData.playedChoppingGameXTimes;
        MiniGameData.PlayedMiningGameXTimes = gameData.playedMiningGameXTimes;
        MiniGameData.CompletedFindTheCureLevel1XTimes = gameData.completedFindTheCureLevel1XTimes;
        MiniGameData.CompletedFindTheCureLevel2XTimes = gameData.completedFindTheCureLevel2XTimes;
        MiniGameData.CompletedFindTheCureLevel3XTimes = gameData.completedFindTheCureLevel3XTimes;
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


