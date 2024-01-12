using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedThePlantUi : MonoBehaviour
{
    public Canvas StoryCanvas;
    public Canvas IntroCanvas;
    public Canvas GameCanvas;
    public Canvas FinishCanvas;

    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);
        IntroCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToStory()
    {
        StoryCanvas.gameObject.SetActive(true);
        IntroCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);
    }

    public void ChangeToIntro()
    {
        StoryCanvas.gameObject.SetActive(false);
        IntroCanvas.gameObject.SetActive(true);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);
    }

    public void ChangeToGame()
    {
        StoryCanvas.gameObject.SetActive(false);
        IntroCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(true);
        FinishCanvas.gameObject.SetActive(false);
    }

    public void ChangeToFinish()
    {
        StoryCanvas.gameObject.SetActive(false);
        IntroCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(true);
    }
}
