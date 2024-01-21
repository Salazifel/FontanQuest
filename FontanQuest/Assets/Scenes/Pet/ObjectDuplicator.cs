using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDuplicator : MonoBehaviour
{
    public GameObject objectToDuplicate; // Assign the object you want to duplicate in the Inspector
    public int numofHay;
    void Start()
    {   
        numofHay = AddGameDataObjects.getNumOfHay();

        objectToDuplicate = GameObject.Find("hay-cube");

        if (objectToDuplicate != null)
        {
            // Get the position and rotation of the object to duplicate
            Vector3 position = objectToDuplicate.transform.position;
            Quaternion rotation = objectToDuplicate.transform.rotation;

            // Instantiate the object multiple times in a loop
            for (int i = 0; i < numofHay; i++)
            {
                GameObject duplicatedObject = Instantiate(objectToDuplicate, position, rotation);

                // // Optionally, set the parent of the duplicated object
                // duplicatedObject.transform.SetParent(objectToDuplicate.transform.parent);
            }
        }
        else
        {
            Debug.LogError("Object to duplicate not assigned!");
        }
    }
}
