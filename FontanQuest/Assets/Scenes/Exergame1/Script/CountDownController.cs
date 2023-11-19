using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownController : MonoBehaviour
{
    [SerializeField] GameObject GetReady;
    public float StartAt;
    float accumTime;
    // Start is called before the first frame update
    void Start()
    {
        GetReady.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        accumTime += Time.deltaTime;
        if (accumTime > 5f)
        {
            GetReady.SetActive(false);
        }
    }
}
