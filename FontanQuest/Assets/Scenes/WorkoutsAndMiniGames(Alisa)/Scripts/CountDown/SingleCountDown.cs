using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SingleCountDown : MonoBehaviour
{
   
    public int StartAt;
    private volatile bool run = true;
    private int currentSecondsLeft;
    private TextMeshProUGUI TextMesh;
    private SingleCountDownManager manager;

    public delegate void UpdateCountDownText(string text);
    public event UpdateCountDownText UpdateCountDown; 
    
    // Start is called before the first frame update
    void Start()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
        TextMesh.text = StartAt.ToString();
        manager = GetComponent<SingleCountDownManager>();
    }

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
        manager.CurrentCountDownFinished();
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
            TextMesh.text = currentSecondsLeft.ToString();
            UpdateCountDown?.Invoke(currentSecondsLeft.ToString());
        }
        else
        {
            Close();
        }
    }
}
