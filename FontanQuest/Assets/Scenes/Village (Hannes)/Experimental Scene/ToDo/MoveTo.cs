using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public NavMeshSurface surface;
    public UnityEngine.AI.NavMeshAgent agent;
    private Vector3 destination;
    // Start is called before the first frame update
    
    public void GoTo(Vector3 pos)
    {
        destination = pos;
        agent.SetDestination(destination);
    }
}
