using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlChoppingGame : MonoBehaviour
{
    public Game WhatGame;
    private DetectChopping _choppingDetect;
    private CountDownManager _countdown;
    private UIControlChopping _ui;
    private bool _firstRound = true;
    [SerializeField]
    private int _prepairingPhaseLengthInSeconds = 3;
    [SerializeField]
    private int _chopingPhaseLengthInSeconds = 20;
    private List<TrainingsInterval> _countdownIntervals;

    public enum Game
    {
        WoodChopping,
        StoneMining
    }
    // Start is called before the first frame update
    void Start()
    {
        _countdown = GetComponent<CountDownManager>();
        _choppingDetect = GetComponent<DetectChopping>();
        _ui = GetComponent<UIControlChopping>();
        _choppingDetect.CutDownTreeEvent += _ui.CutDownTree;
        _countdownIntervals = new List<TrainingsInterval> { new TrainingsInterval(_prepairingPhaseLengthInSeconds, false, null), new TrainingsInterval(_chopingPhaseLengthInSeconds, true, null) };
        _countdown.OnCountDownsDoneEvent += StopChopping;
        _countdown.OnExercisePhaseChangedEvent += ActivePhaseStarted;
        _choppingDetect.HitTree += _ui.HitTree;
    }

    /// <summary>
    /// starts the countdown for the chopping game
    /// if its the first round it will only start the countdown, and make the start button invisible
    /// if it is not the first round it will alse reset the countdown and the choppingDetection and create a new Intervall list and calls the restart method of ui
    /// (the chopingdetection is activated when the event OnExercisePhaseChangedEvent is triggered)
    /// </summary>
    public void StartChoppingGame()
    {
        if (!_firstRound)
        {
            _countdown.TrainingIntervals = new List<TrainingsInterval>(_countdownIntervals);
            _countdown.Reset();
            _choppingDetect.Reset();
            _ui.Restart();
            _countdown.StartCountDown();
            return;
        }
        else
        {
            _firstRound = false;
            _countdown.TrainingIntervals = new List<TrainingsInterval>(_countdownIntervals);
            _countdown.StartCountDown();
            _ui.Restart();
        }
    }

    /// <summary>
    /// Stops the chopping detection
    /// Is called when the OnCountdownDoneEvent is triggered)
    /// </summary>
    public void StopChopping()
    {
        _choppingDetect.StopChopping();
        int cutDownTrees = _choppingDetect.CuttedTrees();
        int reward = Mathf.RoundToInt(cutDownTrees / 2);
        Reward(reward, cutDownTrees);
        _ui.Completed(cutDownTrees, reward);
    }

    /// <summary>
    /// starts the chopping detection for the active phase
    /// Is called when the OnExercisePhaseChangedEvent of the CountDownManagerScript is triggered
    /// </summary>S
    /// <param name="phase"></param>
    public void ActivePhaseStarted(CountDownManager.exercisePhase phase)
    {
        if (CountDownManager.exercisePhase.active == phase)
        {
            _choppingDetect.StartChoping();
            _ui.ActivePhaseStarts();
        }
    }

    private void Reward(int reward, int cutDownTrees)
    {
        switch (WhatGame)
        {
            case Game.WoodChopping:
                MiniGameData.NewWoodChoppingHighScore(cutDownTrees);
                ResourceContainer.changeRes(wood: reward);
                break;
            case Game.StoneMining:
                MiniGameData.NewStoneMiningHighScore(cutDownTrees);
                ResourceContainer.changeRes(stone: reward);            
                break;
        }
    }
}
