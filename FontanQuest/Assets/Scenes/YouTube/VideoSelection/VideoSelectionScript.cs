using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class VideoSelectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<int, string> videoLinks;
    Dictionary<int, string> thumbnailPaths;
    List<string> videoList;

    RawImage video1;
    RawImage video2;
    RawImage video3;
    RawImage video4;
    void Start()
    {
        video1 = GameObject.Find("Video1").GetComponent<RawImage>();
        video2 = GameObject.Find("Video2").GetComponent<RawImage>();
        video3 = GameObject.Find("Video3").GetComponent<RawImage>();
        video4 = GameObject.Find("Video4").GetComponent<RawImage>();

        videoLinks = new Dictionary<int, string>();
        thumbnailPaths = new Dictionary<int, string>();

        // loading in the files
        videoLinks.Add(1, "https://www.youtube.com/watch?v=lK52OxQWH-A");
        thumbnailPaths.Add(1, "YouTubeThumbnails/Super Mario");

        videoLinks.Add(2, "https://www.youtube.com/watch?v=JLVZ3S3qQeo");
        thumbnailPaths.Add(2, "YouTubeThumbnails/Mond Workout");

        videoLinks.Add(3, "https://www.youtube.com/watch?v=zxnIRg9GhEI");
        thumbnailPaths.Add(3, "YouTubeThumbnails/Spiderman");

        videoLinks.Add(4, "https://www.youtube.com/watch?v=QXAux42GOyY");
        thumbnailPaths.Add(4, "YouTubeThumbnails/Tiere");

        videoLinks.Add(5, "https://www.youtube.com/watch?v=5HB8gjcPleI");
        thumbnailPaths.Add(5, "YouTubeThumbnails/Piraten");

        videoLinks.Add(6, "https://www.youtube.com/watch?v=JLEExuQT3ks");
        thumbnailPaths.Add(6, "YouTubeThumbnails/Dinosaurier Workout");

        videoLinks.Add(7, "https://www.youtube.com/watch?v=jtt4HNmDCn4");
        thumbnailPaths.Add(7, "YouTubeThumbnails/Waldspaziergang");

        videoLinks.Add(8, "https://www.youtube.com/watch?v=hMq6VzrvbmY");
        thumbnailPaths.Add(8, "YouTubeThumbnails/Bauernhof");

        videoLinks.Add(9, "https://www.youtube.com/watch?v=_X5wvC9AUGI");
        thumbnailPaths.Add(9, "YouTubeThumbnails/Am Nordpol");

        videoLinks.Add(10, "https://www.youtube.com/watch?v=0qXOMzNynns");
        thumbnailPaths.Add(10, "YouTubeThumbnails/Löwenbaby");

        videoLinks.Add(11, "https://www.youtube.com/watch?v=l1GeISlO0-s");
        thumbnailPaths.Add(11, "YouTubeThumbnails/Dschungel");

        videoLinks.Add(12, "https://www.youtube.com/watch?v=cw6SEsP__6E");
        thumbnailPaths.Add(12, "YouTubeThumbnails/Disko");

        videoLinks.Add(13, "https://www.youtube.com/watch?v=WEXigS7n-10");
        thumbnailPaths.Add(13, "YouTubeThumbnails/Mutter Kind Workout 1");

        videoLinks.Add(14, "https://www.youtube.com/watch?v=qjFGGE5QYRc");
        thumbnailPaths.Add(14, "YouTubeThumbnails/Mutter Kind Workout 2");

        videoLinks.Add(15, "https://www.youtube.com/watch?v=kRn8wD6UwSY");
        thumbnailPaths.Add(15, "YouTubeThumbnails/Mutter Kind Workout 3");

        videoLinks.Add(16, "https://www.youtube.com/watch?v=UAOqH4F3zrw");
        thumbnailPaths.Add(16, "YouTubeThumbnails/Daddy Kind Workout 1");

        videoLinks.Add(17, "https://www.youtube.com/watch?v=UioQfnyKPZw");
        thumbnailPaths.Add(17, "YouTubeThumbnails/Daddy Kind Workout 2");

        videoLinks.Add(18, "https://www.youtube.com/watch?v=Jxyl2RYe1gs");
        thumbnailPaths.Add(18, "YouTubeThumbnails/Taylor Swift Workout");

        videoLinks.Add(19, "https://www.youtube.com/watch?v=ymigWt5TOV8");
        thumbnailPaths.Add(19, "YouTubeThumbnails/Zumba Tanz Workout");

        videoLinks.Add(20, "https://www.youtube.com/watch?v=m9C5fu493Ok");
        thumbnailPaths.Add(20, "YouTubeThumbnails/Zumba Tanz Workout Wellermann");

        videoList = new List<string>();

        SetUpVideoButtons();
    }

    void SetUpVideoButtons()
    {
        // generate random ints
        int min = 1; // Set your minimum value
        int max = videoLinks.Count; // Set your maximum value
        List<int> uniqueInts = new List<int>();
        System.Random rand = new System.Random();

        while (uniqueInts.Count < 4)
        {
            int num = rand.Next(min, max);
            uniqueInts.Add(num);
        }

        video1.texture = Resources.Load<Texture2D>(thumbnailPaths[uniqueInts[0]]);
        video2.texture = Resources.Load<Texture2D>(thumbnailPaths[uniqueInts[1]]);
        video3.texture = Resources.Load<Texture2D>(thumbnailPaths[uniqueInts[2]]);
        video4.texture = Resources.Load<Texture2D>(thumbnailPaths[uniqueInts[3]]);

        videoList.Add(videoLinks[uniqueInts[0]]);
        videoList.Add(videoLinks[uniqueInts[1]]);
        videoList.Add(videoLinks[uniqueInts[2]]);
        videoList.Add(videoLinks[uniqueInts[3]]);
    }

    public void Video1Clicked()
    {
        anyVideoClicked(1);
    }

    public void Video2Clicked()
    {
        anyVideoClicked(2);
    }

    public void Video3Clicked()
    {
        anyVideoClicked(3);
    }

    public void Video4Clicked()
    {
        anyVideoClicked(4);
    }

    private void anyVideoClicked(int videoSelector)
    {
        SaveGameObjects.YouTubeData youTubeData = (SaveGameObjects.YouTubeData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("YouTubeData", 1);
        if (youTubeData == null) {
            youTubeData = (SaveGameObjects.YouTubeData) SaveGameObjects.CreateSaveGameObject("YouTubeData");
        }
        youTubeData.videoToBePlayed = videoList[videoSelector - 1];
        SaveGameMechanic.saveSaveGameObject(youTubeData, "YouTubeData", 1);
        SceneManager.Load("Demo1.2 - Fullscreen");
    }

    public void GoBack()
    {
        SceneManager.Load("Main_Castle");
    }
}
