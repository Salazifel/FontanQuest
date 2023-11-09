using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{   
    Vector3 initialPosition;
    private Material initialMaterial;// Store the initial material here
    private Color initialColor; // Store the initial color here
    // Reference to the ConstantMove script attached to the same GameObject
    // private ConstantMove constantMoveScript;
    void Start()
    {
        initialPosition = transform.position; // Store the initial position
        Renderer renderer = GetComponent<Renderer>();
        initialMaterial = renderer.material; // Store the initial material
        initialColor = renderer.material.color; // Store the initial color

        // // Get a reference to the ConstantMove script
        // constantMoveScript = GetComponent<ConstantMove>();

    }
    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Bumped");
        GetComponent<MeshRenderer>().material.color = Color.red;
        // constantMoveScript.increm = 0; // Access the instance variable
        Invoke("DelayedAction", 0.5f);



    }
        void DelayedAction()
    {   
        transform.position = initialPosition;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = initialMaterial; // Reset the material
        renderer.material.color = initialColor; // Reset the color
        // constantMoveScript.increm = 0.01f; // Reset the value to its initial state

    }
}
