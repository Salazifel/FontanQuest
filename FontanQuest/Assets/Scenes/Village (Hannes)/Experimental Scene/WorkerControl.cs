//using System.Collections;
//using System.Collections.Generic;
//the two on top are not needed
using UnityEngine;
using UnityEngine.AI; // must be included
using UnityStandardAssets.Characters.ThirdPerson;

public class WorkerControl : MonoBehaviour
{

    public Camera cam;
    public NavMeshSurface surface;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // MOVE OUR AGENT
                agent.SetDestination(hit.point);
            }
        }
        
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
