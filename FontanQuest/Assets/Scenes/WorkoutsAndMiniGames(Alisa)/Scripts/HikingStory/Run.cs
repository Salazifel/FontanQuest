using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Run : MonoBehaviour
{
    private int _stepsWalked = 0;
    public int StepsToWalk = 60;
    private int _stepsAtTheBeginning = -1;

    //canvasas
    public Canvas BearLive;
    public Canvas StartCanvas;
    public Canvas YouWon;
    public Canvas YouLost;
    public Canvas YouWonAgainstTheBearCanvas;

    public GameObject BearObject;
    public GameObject CountDownManagerObject;
    public TextMeshProUGUI StepsWalkedText;
    public GameObject FlutterManager;
    public Button StartcountDownButton;

    private flutterCommunication flutterCommunication;
    private SingleCountDownManager _manager;
    private Bear _bear;

    // Start is called before the first frame update
    void Start()
    {
        _manager = CountDownManagerObject.GetComponent<SingleCountDownManager>();
        _manager.CoundDownFinishedEvent += CountDownFinished;
        _bear = BearObject.GetComponent<Bear>();
        _bear.Died += BearDied;
        YouWon.gameObject.SetActive(false);
        YouLost.gameObject.SetActive(false);
        YouWonAgainstTheBearCanvas.gameObject.SetActive(false);
        BearLive.gameObject.SetActive(false);
        StartCanvas.gameObject.SetActive(true);
        flutterCommunication= FlutterManager.GetComponent<flutterCommunication>();
    }

    public void BearDied()
    {
        YouWonAgainstTheBearCanvas.gameObject.SetActive(true);
    }
    public void CountDownFinished()
    {
        flutterCommunication.NewStepValue -= UpdateSteps;
        StartCanvas.gameObject.SetActive(false);
        if (StepsToWalk > _stepsWalked)
        {
            // you lost, fight the bear
            YouLost.gameObject.SetActive(true);
        }
        else
        {
            // you won, you go one extra gold
            ResourceContainer.changeRes(gold: 1);
            YouWon.gameObject.SetActive(true);
        }
    }
    public void FightTheBear()
    {
        YouLost.gameObject.SetActive(false);
        this.gameObject.AddComponent<FindObjectToTouch>();
        BearLive.gameObject.SetActive(true);
    }
    public void StartCountDown()
    {
        _manager.StartCountdown();
        StartcountDownButton.gameObject.SetActive(false);
        flutterCommunication.NewStepValue += UpdateSteps;
    }
    public void YouWonAgainstTheBear()
    {
        Destroy(gameObject.GetComponent<FindObjectToTouch>());
        YouWonAgainstTheBearCanvas.gameObject.SetActive(true);
    }

    public void UpdateSteps(string steps)
    {
        int stepsInt = int.Parse(steps);
        _stepsAtTheBeginning = _stepsAtTheBeginning == -1 ? stepsInt :_stepsAtTheBeginning;
        _stepsWalked = stepsInt - _stepsAtTheBeginning;
        StepsWalkedText.text = _stepsWalked.ToString();
    }
}
