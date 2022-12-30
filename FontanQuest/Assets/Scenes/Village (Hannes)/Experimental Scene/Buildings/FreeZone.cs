using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeZone : MonoBehaviour
{

    public Material[] material;
    private Renderer rend;
    private Material[] mats;

    void OnTriggerStay()
    {
        rend = transform.parent.gameObject.GetComponent<Renderer>();
        mats = rend.materials;
        // if there is also a tmp of materials, the OnTriggerExit could pass on the original colours (all of them)
        for (int i = 0; i < rend.materials.Length; i++)
        {
            mats[i] = material[0];
        }
        rend.materials = mats;

        transform.parent.gameObject.GetComponent<BluePrint>().SendMessage("set_placeable", false);
     }

    void OnTriggerExit()
    {
        for (int i = 0; i < rend.materials.Length; i++)
        {
            mats[i] = material[1];
        }
        rend.materials = mats;

        transform.parent.gameObject.GetComponent<BluePrint>().SendMessage("set_placeable", true);
    }
}
