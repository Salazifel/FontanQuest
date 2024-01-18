using System.Collections;
using System.Collections.Generic;
using LightShaft.Scripts;
using UnityEngine;
using UnityEngine.Video;

public class YouTubeManager : MonoBehaviour
{

    YoutubePlayer youtubePlayer;
    SaveGameObjects.YouTubeData youTubeData;

    void Awake()
    {
        youtubePlayer = GameObject.Find("YoutubePlayer").GetComponent<YoutubePlayer>();
        youTubeData = (SaveGameObjects.YouTubeData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("YouTubeData", 1);
        if (youTubeData != null)
        {
            youtubePlayer.youtubeUrl = youTubeData.videoToBePlayed;
        } 
        else 
        {
            VideoIsDone();
        }
    }

    public void VideoIsDone()
    {
        SceneManager.Load("VideoSelection");
    }
}
