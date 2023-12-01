using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPerfekt : MonoBehaviour
{
    public GameObject Perfekt1;
    [SerializeField] float timeToShowPerfekt = 1f;
    float accumTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Punch1" || collision.gameObject.tag == "Punch2")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            Perfekt1.gameObject.SetActive(true);
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
