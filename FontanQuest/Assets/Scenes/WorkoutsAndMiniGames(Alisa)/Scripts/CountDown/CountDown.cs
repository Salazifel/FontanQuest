using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public int StartAt;
    public CountDownManager Manager;
    private volatile bool run = true;
    private int currentSecondsLeft;

    public delegate void UpdateCountDownText(string text);
    public event UpdateCountDownText UpdateCountDown;
    public void StartCountDown()
    {
        currentSecondsLeft = StartAt;
        StartCoroutine(timer());

    }
    /// <summary>
    /// delets the count down and informs the manager that the countdown has reached the zero
    /// </summary>
    private void Close()
    {
        Manager.CurrentCountDownFinished();
        Destroy(gameObject);
    }

    /// <summary>
    /// pauses the countdown
    /// </summary>
    public void Pause()
    {
        run = false;
    }

    /// <summary>
    /// let the countdown continue after a pause
    /// </summary>
    public void ContinueAfterPause()
    {
        run = true;
        StartCoroutine(timer());
    }

    /// <summary>
    /// counts down every second
    /// </summary>
    /// <returns></returns>
    IEnumerator timer()
    {
        while (run)
        {
            CountOneDown();
            yield return new WaitForSeconds(1);
        }
    }

    /// <summary>
    /// performs the update on the current seconds left and the text mesh
    /// </summary>
    private void CountOneDown()
    {
        if (currentSecondsLeft > 0)
        {
            currentSecondsLeft--;
            UpdateCountDown?.Invoke(currentSecondsLeft.ToString());
        }
        else
        {
            Close();
        }
    }
}
