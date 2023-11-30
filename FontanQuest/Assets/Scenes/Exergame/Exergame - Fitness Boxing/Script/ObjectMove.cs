using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject Perfekt1;
    public GameObject Perfekt2;
    [SerializeField] float timeToShowPerfekt = 6f;
    float accumTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed*Time.deltaTime, 0);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallCube1")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            Perfekt1.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "SmallCube2")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            Perfekt2.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        accumTime += Time.fixedDeltaTime;

        if (Perfekt1.activeSelf && accumTime > timeToShowPerfekt)
        {
            Perfekt1.gameObject.SetActive(false);
        }

        if (Perfekt2.activeSelf && accumTime > timeToShowPerfekt)
        {
            Perfekt2.gameObject.SetActive(false);
        }
    }
}
