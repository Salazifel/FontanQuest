using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHintRight : MonoBehaviour
{
    public GameObject Right;
    [SerializeField] float timeToShowHint = 2f;
    float accumTime;
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
        if (collision.gameObject.CompareTag("PlantA") || collision.gameObject.CompareTag("PlantB"))
        {
            accumTime = 0f;
            Right.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        accumTime += Time.fixedDeltaTime;

        if (Right.activeSelf && accumTime > timeToShowHint)
        {
            Right.gameObject.SetActive(false);
            accumTime = 0f;  
        }
    }
}
