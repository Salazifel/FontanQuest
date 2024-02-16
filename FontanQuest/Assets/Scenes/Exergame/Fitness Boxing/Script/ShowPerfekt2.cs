using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPerfekt2 : MonoBehaviour
{
    public GameObject Perfekt2;
    [SerializeField] float timeToShowPerfekt = 1f;
    float accumTime;
    public AudioSource Punch1;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Punch1" || collision.gameObject.tag == "Punch2")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            if (SmartWatchData.pastHeartActivity == true || SmartWatchData.pastStepActivitiy)
            {
                Perfekt2.gameObject.SetActive(true);
                transform.parent.GetComponent<PunchManager>().UpdateScore(20);
                Punch1.Play();
            }
            else if (SmartWatchData.pastHeartActivity6sec == true && SmartWatchData.pastStepActivitiy6sec)
            {
                Perfekt2.gameObject.SetActive(Random.Range(0, 2) == 0); // 0 or 1
                if (Perfekt2.gameObject.activeSelf == true)
                {
                    Punch1.Play();
                    transform.parent.GetComponent<PunchManager>().UpdateScore(20);
                }
            }
            else
            {
                Perfekt2.gameObject.SetActive(false);
            }    
            // gameObject.SetActive(false);
            // Debug.Log("SmallCube2 collision");
        }
    }

    void FixedUpdate()
    {
        accumTime += Time.fixedDeltaTime;

        if (Perfekt2.activeSelf && accumTime > timeToShowPerfekt)
        {
            Perfekt2.gameObject.SetActive(false);
            accumTime = 0f;  // Reset accumTime after hiding "Perfekt"
            // Debug.Log("Hiding Perfekt2");
        }
    }
}
