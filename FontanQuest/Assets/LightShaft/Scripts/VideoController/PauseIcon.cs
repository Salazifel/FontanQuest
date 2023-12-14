﻿using System.Collections;
using System.Collections.Generic;
using LightShaft.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PauseIcon : MonoBehaviour {

    public YoutubePlayer p;
    public UnityEngine.UI.Image playImage;
    public UnityEngine.UI.Image pauseImage;


    private void FixedUpdate()
    {
        if (p.pauseCalled)
        {
            playImage.gameObject.SetActive(true);
            pauseImage.gameObject.SetActive(false);
        }
        else
        {
            pauseImage.gameObject.SetActive(true);
            playImage.gameObject.SetActive(false);
        }
    }
}