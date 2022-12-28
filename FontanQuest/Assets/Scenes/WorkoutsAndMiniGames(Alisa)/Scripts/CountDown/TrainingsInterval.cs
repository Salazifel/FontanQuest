using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingsInterval : MonoBehaviour
{
    public int LengthInSeconds;
    public bool ActivePhase; //true --> active Phase, false --> resting Phase
    public Animation ExerciseAnimation = null;
    public float MinHeartRate;
    public float HeartRateForMaxReward;
    private List<float> HeartRate = new List<float>();

    public TrainingsInterval(int lengthInSeconds, bool activePhase, Animation animation)
    {
        LengthInSeconds = lengthInSeconds;
        ActivePhase = activePhase;
        ExerciseAnimation = animation;
    }

    public float HeartRateAverage()
    {
        if (HeartRate.Count > 0)
        {
            float mean = 0;
            for (int i = 0; i < HeartRate.Count; i++)
            {
                mean = +HeartRate[i];
            }
            return mean / HeartRate.Count;
        }
        return 0;
    }

    /// <summary>
    /// calcualte how intense the interval has been performed by the average heart rate during the interval
    /// and the intended heart rate
    /// </summary>
    /// <returns></returns> float between 0 and 1, where 1 stands for a high intensity and 0 for to low intensity
    public float Performenc()
    {
        float performance = 0;
        if (ActivePhase)
        {
            float average = HeartRateAverage();
            if (average > MinHeartRate)
            {
                performance = average > HeartRateForMaxReward ? 1 : (float)Math.Round(HeartRateForMaxReward / average, 1);
            }
        }
        return performance;
    }

    public void NewHeartRate(float hr)
    {
        HeartRate.Add(hr);
    }
}
