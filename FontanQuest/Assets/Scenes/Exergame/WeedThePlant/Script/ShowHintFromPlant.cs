using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHintFromPlant : MonoBehaviour
{
    public GameObject Left;
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
            Left.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        accumTime += Time.fixedDeltaTime;

        if (Left.activeSelf && accumTime > timeToShowHint)
        {
            Left.gameObject.SetActive(false);
            accumTime = 0f; 
        }
    }
}
