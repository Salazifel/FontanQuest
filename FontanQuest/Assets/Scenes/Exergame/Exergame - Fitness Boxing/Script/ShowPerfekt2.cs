using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPerfekt2 : MonoBehaviour
{
    public GameObject Perfekt2;
    [SerializeField] float timeToShowPerfekt = 1f;
    float accumTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Punch1" || collision.gameObject.tag == "Punch2")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            Perfekt2.gameObject.SetActive(true);
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
