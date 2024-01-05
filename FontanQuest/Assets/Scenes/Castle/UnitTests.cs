using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTests : MonoBehaviour
{
    void LateUpdate() {
        StaticResources.addNumOfCoins(5);
        GameObject gO = GameObject.Find("testAudioSource");
        gO.GetComponent<AudioSource>().Play();
    }
}
