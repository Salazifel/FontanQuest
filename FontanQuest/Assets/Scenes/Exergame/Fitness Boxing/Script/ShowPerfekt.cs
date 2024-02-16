using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPerfekt : MonoBehaviour
{
    public GameObject Perfekt1;
    [SerializeField] float timeToShowPerfekt = 1f;
    float accumTime;
    public AudioSource Punch2;
    public GameObject Green;
    public GameObject Yellow;
    public GameObject Red;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Punch1" || collision.gameObject.tag == "Punch2")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            if (SmartWatchData.pastHeartActivity == true || SmartWatchData.pastStepActivitiy)
            {
                Green.gameObject.SetActive(true);
                Yellow.gameObject.SetActive(false);
                Red.gameObject.SetActive(false);
                Perfekt1.gameObject.SetActive(true);
                Punch2.Play();
            }
            else if (SmartWatchData.pastHeartActivity6sec == true && SmartWatchData.pastStepActivitiy6sec)
            {
                Green.gameObject.SetActive(false);
                Yellow.gameObject.SetActive(true);
                Red.gameObject.SetActive(false);
                Perfekt1.gameObject.SetActive(Random.Range(0, 2) == 0); // 0 or 1
                if (Perfekt1.gameObject.activeSelf == true)
                {
                    Punch2.Play();
                }

            }
            else
            {
                Green.gameObject.SetActive(false);
                Yellow.gameObject.SetActive(false);
                Red.gameObject.SetActive(true);
                Perfekt1.gameObject.SetActive(false);
            }
            // gameObject.SetActive(false);
            // Debug.Log("SmallCube1 collision");
        }
    }

    void FixedUpdate()
    {
        accumTime += Time.fixedDeltaTime;

        if (Perfekt1.activeSelf && accumTime > timeToShowPerfekt)
        {
            Perfekt1.gameObject.SetActive(false);
            accumTime = 0f;  // Reset accumTime after hiding "Perfekt"
            // Debug.Log("Hiding Perfekt1");
        }
    }
}
