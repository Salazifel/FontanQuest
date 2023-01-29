using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class MedalManager : MonoBehaviour
{
    public Sprite Level0Image;
    public Sprite Level1Image;
    public Sprite Level2Image;
    public Sprite Level3Image;
    public Sprite Level4Image;

    private List<Medal> Medals = new List<Medal>();

    public Medal AmountOfDiamondMedals;
    public Medal AmountOfGoldMedals;
    public Medal AmountOfSilverMedals;
    public Medal AmountOfBronceMedals;
    public Medal WalkedXStepsOnOneDay;
    public Medal ChoppingHighScore;
    public Medal MiningHighScore;
    public Medal PlayedChoppingGameXTimes;
    public Medal PlayedMiningGameXTimes;
    public Medal PlayedFindTheCureLevel1GameXTimes;
    public Medal PlayedFindTheCureLevel2GameXTimes;
    public Medal PlayedFindTheCureLevel3GameXTimes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitOneSecondForLoading());



    }

    IEnumerator WaitOneSecondForLoading()
    {
        yield return new WaitForSeconds(0.5f);
        ChoppingHighScore.Value = MiniGameData.ChoppingHighscore;
        MiningHighScore.Value = MiniGameData.StoneMiningHighscore;
        PlayedChoppingGameXTimes.Value = MiniGameData.PlayedChoppingGameXTimes;
        PlayedMiningGameXTimes.Value = MiniGameData.PlayedMiningGameXTimes;
        PlayedFindTheCureLevel1GameXTimes.Value = MiniGameData.CompletedFindTheCureLevel1XTimes;
        PlayedFindTheCureLevel2GameXTimes.Value = MiniGameData.CompletedFindTheCureLevel2XTimes;
        PlayedFindTheCureLevel3GameXTimes.Value = MiniGameData.CompletedFindTheCureLevel3XTimes;

        Medals = new List<Medal>() { WalkedXStepsOnOneDay, ChoppingHighScore, MiningHighScore, PlayedChoppingGameXTimes, PlayedMiningGameXTimes, PlayedFindTheCureLevel1GameXTimes, PlayedFindTheCureLevel2GameXTimes, PlayedFindTheCureLevel3GameXTimes };
        UpdateAmountOfMedalMedals();
    }

    public void UpdateAmountOfMedalMedals()
    {
        AmountOfBronceMedals.Value = Medals.FindAll(x => x.CurrentLevel >= 1).Count;
        AmountOfSilverMedals.Value = Medals.FindAll(x => x.CurrentLevel >= 2).Count;
        AmountOfGoldMedals.Value = Medals.FindAll(x => x.CurrentLevel >= 3).Count;
        AmountOfDiamondMedals.Value = Medals.FindAll(x => x.CurrentLevel == 4).Count;
    }

}
