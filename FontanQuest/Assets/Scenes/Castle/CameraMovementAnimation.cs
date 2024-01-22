using System;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraMovementAnimation : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject startObject;
    public GameObject objectToBeMoved;
    public float transitionTime = 3.0f; // Duration of the transition in seconds
    public float elapsedTime = 0.0f;
    public int totalStepsNeeded;
    public int stepsTaken;
    public bool AnimationIsDone;

    public enum StepOptions
    {
        step_count,
        time_count
    }

    public void initializeAnimation()
    {
        objectToBeMoved.transform.position = startObject.transform.position;
        objectToBeMoved.transform.rotation = startObject.transform.rotation;
    }

    public string step_to_target(StepOptions stepOptions, int _totalStepsNeeded=0)
    {
        if (!AnimationIsDone) 
        {
            if (stepOptions == StepOptions.time_count)
            {
                if (elapsedTime < transitionTime)
                {
                    // Calculate the fraction of the journey completed
                    float fraction = elapsedTime / transitionTime;

                    // Interpolate position and rotation
                    objectToBeMoved.transform.position = Vector3.Lerp(startObject.transform.position, targetObject.transform.position, fraction);
                    objectToBeMoved.transform.rotation = Quaternion.Slerp(startObject.transform.rotation, targetObject.transform.rotation, fraction);

                    // Increment the time elapsed
                    elapsedTime += Time.deltaTime;
                }
                else 
                {
                    AnimationIsDone = true;
                }
            }
            else 
            {
                if (_totalStepsNeeded > 0)
                {
                    totalStepsNeeded = _totalStepsNeeded;
                }

                if (stepsTaken < totalStepsNeeded)
                {
                    // Calculate the fraction of the journey completed
                    float fraction = (float)stepsTaken / totalStepsNeeded;

                    // Interpolate position and rotation
                    objectToBeMoved.transform.position = Vector3.Lerp(startObject.transform.position, targetObject.transform.position, fraction);
                    objectToBeMoved.transform.rotation = Quaternion.Slerp(startObject.transform.rotation, targetObject.transform.rotation, fraction);

                    // Increment the step
                    stepsTaken++;
                }
                else
                {
                    AnimationIsDone = true;
                    return "Done";
                }

            }

            return "Stepped";
        }
        else
        {
            return "Error";
        }
    }
}
