using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HikkingStoryPartCanvasManager : MonoBehaviour
{
    public Canvas GameCanvas;
    public Canvas QuitCanvas;
    public Button NextChapterButton;

    // Start is called before the first frame update
    void Start()
    {
        GameCanvas.gameObject.SetActive(true);
        QuitCanvas.gameObject.SetActive(false);
        if (NextChapterButton != null)
        {
            Debug.Log("deactivate Button");
            NextChapterButton.gameObject.SetActive(false);
        }
    }

    public void ActivateNextChapterButton()
    {
        Debug.Log("activate button");
        NextChapterButton.gameObject.SetActive(true);
    }
    public void ContinueGame()
    {
        QuitCanvas.gameObject.SetActive(false);
    }

    public void NextChapterButtonClick()
    {
        HikkingStoryControll.currentIndex++;
        var links = GetComponent<OpenLinks>();
        if (links == null)
        {
            links = this.gameObject.AddComponent<OpenLinks>();
        }
        links.LoadHikkingStory();
    }

    public void QuitGame()
    {
        HikkingStoryControll.currentIndex = 0;
        Debug.Log("Current index " + HikkingStoryControll.currentIndex);
        var links = GetComponent<OpenLinks>();
        if(links == null)
        {
          links =  this.gameObject.AddComponent<OpenLinks>();
        }
        links.LoadGameSelection();
    }
    public void ShowQuitGameWindow()
    {
        QuitCanvas.gameObject.SetActive(true);
    }
}
