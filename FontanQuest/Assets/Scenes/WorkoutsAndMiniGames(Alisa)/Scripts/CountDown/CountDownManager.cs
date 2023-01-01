using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    //events
    public event OnExercisePhaseChanged OnExercisePhaseChangedEvent;
    public delegate void OnExercisePhaseChanged(exercisePhase phase);
    public delegate void OnCountDownsDone();
    public event OnCountDownsDone OnCountDownsDoneEvent;

    //properties
    public GameObject CountDownUI;
    public GameObject CountDownPrefab;
    //public GameObject FitnessTracker;
    //private IFitnessTracker fakeFitnessTracker;
    public List<TrainingsInterval> TrainingIntervals;
    public Vector3 countdownPosition = new Vector3(50, 0, 300);
    private CountDown _currentCountDown;
    private CountDownUI ui;
    private int _currentIndex = -1;
    private int _pauseCounter = 0;


    public enum exercisePhase
    {
        rest,
        pause,
        active
    };

    // Start is called before the first frame update
    /// <summary>
    /// initilizes the countdownmanager
    /// </summary>
    void Start()
    {
        /// test training intervals and training interval list;
        TrainingsInterval interval1 = new TrainingsInterval(3, false, null);
        TrainingsInterval interval2 = new TrainingsInterval(10, true, null);
        TrainingIntervals = new List<TrainingsInterval> { interval1, interval2 };
        ui = CountDownUI.GetComponent<CountDownUI>();
        /*fakeFitnessTracker = FitnessTracker.GetComponent<FakeFittnessTracker>();
        if(fakeFitnessTracker != null)
        {
            fakeFitnessTracker.OnPublishHeartRateValue += AddHeartRateValueToInterval;
        }*/

    }

    /// <summary>
    /// starts the countdown
    /// </summary>
    public void StartCountDown()
    {
        if (TrainingIntervals != null)
        {
            BuildAndStartCountDown();
        }
    }

    public void Reset()
    {
        _currentIndex = -1;
    }


    /// <summary>
    /// pauses the current count down 
    /// </summary>
    public void Pause()
    {
        _currentCountDown.Pause();
        OnExercisePhaseChangedEvent?.Invoke(exercisePhase.pause);
        _pauseCounter++;
    }

    /// <summary>
    /// let the countdown run again after a pause call
    /// updates the UI about the exercise phase
    /// </summary>
    public void Continue()
    {
        _currentCountDown.ContinueAfterPause();
        exercisePhase phase = TrainingIntervals[_currentIndex].ActivePhase ? exercisePhase.active : exercisePhase.rest;
        OnExercisePhaseChangedEvent?.Invoke(phase);
    }

    /// <summary>
    /// is called when all count downs of the list TrainingIntervals have been executed
    /// or the count down manager is stopped by the user 
    /// </summary>
    public void Completed()
    {
        OnCountDownsDoneEvent?.Invoke();
        if (_currentIndex == TrainingIntervals.Count - 1)
        {
            Debug.Log("completed CountdownManager");
        }
        else
        {
            Pause();
            Debug.Log("Stopped CountdownManager");
        }
    }

    /// <summary>
    /// is called from the count down when it finished and starts the next count down in line
    /// </summary>
    public void CurrentCountDownFinished()
    {
        if (_currentIndex < TrainingIntervals.Count - 1)
        {
            BuildAndStartCountDown();
        }
        else
        {
            _currentCountDown = null;
            Completed();
        }
    }

    /// <summary>
    /// starts the next countdown 
    /// updates the _currentIndex
    /// invokes an event to update the UI for the Exercise Phase
    /// </summary>
    private void BuildAndStartCountDown()
    {
        if (_currentIndex < TrainingIntervals.Count)
        {
            _currentIndex++;
            GameObject countdownObject = Instantiate(CountDownPrefab);
            _currentCountDown = countdownObject.GetComponent<CountDown>();
            _currentCountDown.Manager = this;
            _currentCountDown.StartAt = TrainingIntervals[_currentIndex].LengthInSeconds + 1;// plus one to make the max value visible
            _currentCountDown.StartCountDown();
                  if (ui != null)
            {
                _currentCountDown.UpdateCountDown += ui.UpdateCountDown;
                ui.Max = TrainingIntervals[_currentIndex].LengthInSeconds ;
            }
            exercisePhase phase = TrainingIntervals[_currentIndex].ActivePhase ? exercisePhase.active : exercisePhase.rest;
            OnExercisePhaseChangedEvent?.Invoke(phase);
      
        }
    }


    public void AddHeartRateValueToInterval(float hr)
    {
        TrainingIntervals[_currentIndex].NewHeartRate(hr);
    }

    /// <summary>
    /// calculates the performance of the performed active phases and the average heart rate in the resting phases
    /// </summary>
    /// <returns></returns> tuple of(performance, heartRateAtRest)
    public (float, float) CalculateOverallPerformance()
    {
        float performance = 0;
        float heartRateAtRest = 0;
        int numberOfActivePhases = 0;
        int numberOfRestPhases = 0;
        for (int i = 0; i < TrainingIntervals.Count; i++)
        {
            if (TrainingIntervals[i].ActivePhase)
            {
                performance = +TrainingIntervals[i].Performenc();
                numberOfActivePhases++;
            }
            else
            {
                heartRateAtRest = +TrainingIntervals[i].HeartRateAverage();
                numberOfActivePhases++;
            }
        }
        performance = performance / numberOfActivePhases;
        heartRateAtRest = numberOfRestPhases != 0 ? heartRateAtRest / numberOfRestPhases : 0;
        return (performance, heartRateAtRest);
    }
}
