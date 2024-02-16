using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPerfekt2 : MonoBehaviour
{
    public GameObject Perfekt2;
    [SerializeField] float timeToShowPerfekt = 1f;
    float accumTime;
    public AudioSource Punch1;
    public GameObject Green;
    public GameObject Yellow;
    public GameObject Red;

    PunchManager punchManager;

    private void Start()
    {
        punchManager = GameObject.Find("PunchManager").GetComponent<PunchManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Punch1" || collision.gameObject.tag == "Punch2")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            if (Green.gameObject.activeSelf == true)
            {
                Perfekt2.gameObject.SetActive(true);
                Punch1.Play();
                punchManager.UpdateScore(20);
            }
            else if (Yellow.gameObject.activeSelf == true)
            {
                Perfekt2.gameObject.SetActive(Random.Range(0, 2) == 0); // 0 or 1
                if (Perfekt2.gameObject.activeSelf == true)
                {
                    Punch1.Play();
                    punchManager.UpdateScore(20);
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
