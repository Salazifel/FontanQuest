using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeZone : MonoBehaviour
{

    public Material[] material;
    private Renderer rend;
    private Material[] mats;

    private Collider col;

    void OnTriggerStay(Collider other)
    {   
        col = other;
        set_Red();
     }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "BuildableZone"){
            for (int i = 0; i < rend.materials.Length; i++)
            {
                mats[i] = material[0];
            }
            rend.materials = mats;
            return;
        }
        set_Green();
    }

    void Start()
    {
        rend = transform.parent.gameObject.GetComponent<Renderer>();
        mats = rend.materials;
    }

    void set_Red()
    {
        if (col.gameObject.name == "BuildableZone"){
            set_Green();
            return;
        }

        // if there is also a tmp of materials, the OnTriggerExit could pass on the original colours (all of them)
        for (int i = 0; i < rend.materials.Length; i++)
        {
            mats[i] = material[0];
        }
        rend.materials = mats;

        transform.parent.gameObject.GetComponent<BluePrint>().SendMessage("set_placeable", false);
    }

    void set_Green()
    {
        for (int i = 0; i < rend.materials.Length; i++)
        {
            mats[i] = material[1];
        }
        rend.materials = mats;

        transform.parent.gameObject.GetComponent<BluePrint>().SendMessage("set_placeable", true);
    }
}
