using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public string Name { get; private set; }
    public int HighScore { get; private set; }
    public int TotalPlayedTimes { get; private set; }
    public Reward Reward1;
    public Reward Reward2;
    public int EP;

    public Game(string name,Reward reward1, Reward reward2)
    {
        Name = name;
        Reward1 = reward1;
        Reward2 = reward2;
        HighScore = 0;
        TotalPlayedTimes = 0;
    }

    public void NewHighScore(int highScore)
    {
        HighScore = highScore;
    }
    public void CompletedGame()
    {
        TotalPlayedTimes++;
    }
}
