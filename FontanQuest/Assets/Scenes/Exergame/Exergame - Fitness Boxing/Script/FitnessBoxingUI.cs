using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessBoxingUI : MonoBehaviour
{

    public Canvas StoryCanvas;
    public Canvas GameCanvas;
    public Canvas FinishCanvas;


    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToGame()
    {
        StoryCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(true);
        FinishCanvas.gameObject.SetActive(false);
    }

    public void ChangeToComplete()
    {
        StoryCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(true);
    }
}
