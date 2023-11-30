using System.Collections;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject Perfekt1;
    public GameObject Perfekt2;
    [SerializeField] float timeToShowPerfekt = 3f;
    private bool perfekt1Shown = false;
    private bool perfekt2Shown = false;

    Coroutine perfekt1Coroutine;
    Coroutine perfekt2Coroutine;

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallCube1" && !perfekt1Shown)
        {
            if (perfekt1Coroutine != null)
                StopCoroutine(perfekt1Coroutine);

            perfekt1Coroutine = StartCoroutine(ShowAndHidePerfekt(Perfekt1, gameObject, () => perfekt1Shown = false));
            Debug.Log("SmallCube1 collision");
        }
        else if (collision.gameObject.tag == "SmallCube2" && !perfekt2Shown)
        {
            if (perfekt2Coroutine != null)
                StopCoroutine(perfekt2Coroutine);

            perfekt2Coroutine = StartCoroutine(ShowAndHidePerfekt(Perfekt2, gameObject, () => perfekt2Shown = false));
            Debug.Log("SmallCube2 collision");
        }
    }

    IEnumerator ShowAndHidePerfekt(GameObject perfekt, GameObject objectToHide, System.Action onPerfektHidden)
    {
        Debug.Log($"Showing {perfekt.name}");
        perfekt.SetActive(true);
        objectToHide.SetActive(false);
        yield return new WaitForSeconds(timeToShowPerfekt);
        Debug.Log($"Hiding {perfekt.name}");
        perfekt.SetActive(false);
        onPerfektHidden?.Invoke();
    }
}




/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float speed = 0.5f;
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
        transform.Translate(0, speed*Time.deltaTime, 0);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallCube1")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            Perfekt1.gameObject.SetActive(true);
            gameObject.SetActive(false);
            perfekt1Shown = true;
            Debug.Log("SmallCube1 collision");
        }
        else if (collision.gameObject.tag == "SmallCube2")
        {
            accumTime = 0f;  // Reset accumTime before showing "Perfekt"
            Perfekt2.gameObject.SetActive(true);
            gameObject.SetActive(false); 
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
*/