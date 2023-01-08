using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVisibilityController : MonoBehaviour
{
    public GameObject ChoppingGameButton;
    public GameObject StoneMiningGameButton;
    public GameObject HikkingStoryFindTheCureButton;
    public GameObject SuperMarioYouTubeGameButton;
    public GameObject DisneyDanceYouTubeGameButton;


    // Start is called before the first frame update
    void Start()
    {
        if (ChoppingGameButton != null)
        {
            ChoppingGameButton.SetActive(GamesVisibiltyForKids.ChoppingGame);
        }
        if (StoneMiningGameButton != null)
        {
            StoneMiningGameButton.SetActive(GamesVisibiltyForKids.StoneMiningGame);
        }
        if (HikkingStoryFindTheCureButton != null)
        {
            HikkingStoryFindTheCureButton.SetActive(GamesVisibiltyForKids.HikkingStoryFindTheCure);
        }
        if (SuperMarioYouTubeGameButton != null)
        {
            SuperMarioYouTubeGameButton.SetActive(GamesVisibiltyForKids.SuperMarioYouTubeGame);
        }
        if (DisneyDanceYouTubeGameButton != null)
        {
            DisneyDanceYouTubeGameButton.SetActive(GamesVisibiltyForKids.DisneyDanceYouTubeGame);
        }
    }
}

public static class GamesVisibiltyForKids
{
    public static bool ChoppingGame = true;
    public static bool StoneMiningGame = true;
    public static bool HikkingStoryFindTheCure = true;
    public static bool SuperMarioYouTubeGame = true;
    public static bool DisneyDanceYouTubeGame = true;

    public static void DisableYoutubeGames()
    {
        GamesVisibiltyForKids.YouTubeGamesSetVisibility(false);
    }

    public static void EnableYouTubeGames()
    {
        GamesVisibiltyForKids.YouTubeGamesSetVisibility(true);
    }
    public static void YouTubeGamesSetVisibility(bool visibile)
    {
        SuperMarioYouTubeGame = visibile;
        DisneyDanceYouTubeGame = visibile;
    }
}
