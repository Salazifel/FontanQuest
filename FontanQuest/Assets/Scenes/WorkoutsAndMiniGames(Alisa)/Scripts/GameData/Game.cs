using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public string Name { get; private set; }
    public int HighScore { get; private set; }
    public int TotalPlayedTimes { get; private set; }
    public int EP;

    public Game(string name)
    {
        Name = name;
        HighScore = 0;
        TotalPlayedTimes = 0;
    }

    public void NewHighScore(int score)
    {
        HighScore = HighScore < score ? score : HighScore;
    }
    public void CompletedGame()
    {
        TotalPlayedTimes++;
    }
}
