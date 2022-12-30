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
    
    public bool GoTo(Vector3 pos)
    {
        // GetComponent<RandomWalking>().enabled = false;
        agent.SetDestination(transform.position);
        NavMeshPath path = new NavMeshPath();
        if (agent.CalculatePath(pos, path))
        {
            agent.ResetPath();
            agent.SetDestination(pos);
            return true;
        }
        return false;
    }

    public void StopPath()
    {
        agent.SetDestination(transform.position);
        // IdleWalking();
    }

    public void IdleWalking()
    {
        GetComponent<RandomWalking>().enabled = true;
    }
}
