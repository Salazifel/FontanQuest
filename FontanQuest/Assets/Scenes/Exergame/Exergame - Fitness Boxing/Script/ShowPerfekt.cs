using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPerfekt : MonoBehaviour
{
    public GameObject Perfekt1;
    public GameObject Perfekt2;
    [SerializeField] float timeToShowPerfekt = 3f;
    float accumTime;
    private bool perfekt1Shown = false;
    private bool perfekt2Shown = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Punch1")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            Perfekt1.gameObject.SetActive(true);
            // gameObject.SetActive(false);
            perfekt1Shown = true;
            Debug.Log("SmallCube1 collision");
        }
        else if (collision.gameObject.tag == "Punch2")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            Perfekt2.gameObject.SetActive(true);
            // gameObject.SetActive(false);
            perfekt2Shown = true;
            Debug.Log("SmallCube2 collision");
        }
    }

    void FixedUpdate()
    {
        accumTime += Time.fixedDeltaTime;

        if (Perfekt1.activeSelf && accumTime > timeToShowPerfekt)
        {
            Perfekt1.gameObject.SetActive(false);
            accumTime = 0f;  // Reset accumTime after hiding "Perfekt"
            perfekt1Shown = false;
            Debug.Log("Hiding Perfekt1");
        }

        if (Perfekt2.activeSelf && accumTime > timeToShowPerfekt)
        {
            Perfekt2.gameObject.SetActive(false);
            accumTime = 0f;  // Reset accumTime after hiding "Perfekt"
            perfekt2Shown = false;
            Debug.Log("Hiding Perfekt2");
        }
    }
}
