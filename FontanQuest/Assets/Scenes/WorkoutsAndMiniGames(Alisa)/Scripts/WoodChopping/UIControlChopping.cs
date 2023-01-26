using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControlChopping : MonoBehaviour
{

    public TextMeshProUGUI TreeCounter;
    public TextMeshProUGUI FinalTreeCounter;
    public TextMeshProUGUI FinalReward;
    public TextMeshProUGUI FeedBack;
    public TextMeshProUGUI Highscore;
    public GameObject GetReadyText;

    public Canvas StartCanvas;
    public Canvas GamingCanvas;
    public Canvas CompletedCanvas;

    public Animator TreeAnimator;
    public Animator AxeAnimator;
    public ControlChoppingGame.Game Game;


    private string _hitTrigger = "Hit";
    private string _fallTrigger = "Fall";
    // Start is called before the first frame update
    void Start()
    {
        StartCanvas.gameObject.SetActive(true);
        GamingCanvas.gameObject.SetActive(false);
        CompletedCanvas.gameObject.SetActive(false);
    }

    public void Completed(int numberOfTrees, int reward)
    {
        CompletedCanvas.gameObject.SetActive(true);
        GamingCanvas.gameObject.SetActive(false);
        FinalReward.text = reward.ToString();
        FinalTreeCounter.text = numberOfTrees.ToString();
        if(Game == ControlChoppingGame.Game.StoneMining)
        {
            Highscore.text = MiniGameData.StoneMiningHighscore.ToString();
        }
        if (Game == ControlChoppingGame.Game.WoodChopping)
        {
            Highscore.text = MiniGameData.ChoppingHighscore.ToString();
        }

    }

    public void Restart()
    {
        CompletedCanvas.gameObject.SetActive(false);
        GamingCanvas.gameObject.SetActive(true);
        StartCanvas.gameObject.SetActive(false);
        TreeCounter.text = "0";
        if (GetReadyText != null)
        {
            GetReadyText.gameObject.SetActive(true);
        }
    }

    public void HitTree()
    {
        if(AxeAnimator != null)
        {
            AxeAnimator.SetTrigger(_hitTrigger);
        }
        if(TreeAnimator != null)
        {
            TreeAnimator.SetTrigger(_hitTrigger);
        }
    }

    public void CutDownTree(int numberOfTrees)
    {
        if(TreeAnimator!= null)
        {
            TreeAnimator.SetTrigger(_fallTrigger);
        }
        if (TreeCounter != null)
        {
            TreeCounter.text = numberOfTrees.ToString();
        }
        if(TreeAnimator != null)
        {
            TreeAnimator.SetTrigger("Fall");
        }
    }

    public void ActivePhaseStarts()
    {
        if (GetReadyText != null)
        {
            GetReadyText.gameObject.SetActive(false);
        }
    }
}
