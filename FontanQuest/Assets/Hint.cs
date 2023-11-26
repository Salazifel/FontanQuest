using UnityEngine;

public class Hint : MonoBehaviour
{
    public GameObject HintObject;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hint")
        {
            ShowHint();
            Debug.Log("Cross");
        }
        else
        {
            HideHint();
            Debug.Log("Already Cross");
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Hint"))
        {
            Debug.Log("Collided with Hint layer");
            HintObject.SetActive(true);
        }
        else
        {
            Debug.Log("Collided with other layer");
            HintObject.SetActive(false);
        }
    }


    void ShowHint()
    {
        if (HintObject != null)
        {
            SpriteRenderer spriteRenderer = HintObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true;
            }
            else
            {
                Debug.LogError("SpriteRenderer component not found on the HintObject.");
            }
        }
    }

    void HideHint()
    {
        if (HintObject != null)
        {
            SpriteRenderer spriteRenderer = HintObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
            else
            {
                Debug.LogError("SpriteRenderer component not found on the HintObject.");
            }
        }


    }
}
