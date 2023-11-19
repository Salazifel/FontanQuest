using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHint : MonoBehaviour
{
    [SerializeField] float timeToShowHint;
    float accumTime;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        accumTime += Time.deltaTime;

        if (accumTime > timeToShowHint)
        {
            spriteRenderer.enabled = true;
            accumTime = 0f;
        }

        if (accumTime > 3f)
        {
            spriteRenderer.enabled = false;
        }


    }
}
