using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarUnitTests : MonoBehaviour
{
    // Start is called before the first frame update
    void LateUpdate()
    {
        GameObject pet = GameObject.Find("Pet");
        AnimalManager animalManager = pet.GetComponent<AnimalManager>();
        animalManager.ActivateAnimal("Wolf_01");     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
