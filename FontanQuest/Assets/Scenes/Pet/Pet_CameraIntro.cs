using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Pet_CameraIntro : MonoBehaviour
{
    public Transform targetTransform; // Assign the target transform in the inspector
    private Vector3 startPosition;
    private Vector3 bucketPosition;
    private Quaternion startRotation;
    private float transitionTime = 3.0f; // Duration of the transition in seconds
    private float elapsedTime = 0.0f;
    public bool AnimationIsDone;
    private bool StartAnimation = false;

    private Boolean reverseAnimation;
    // Post Processing
    public PostProcessVolume postProcessVolume;
    private DepthOfField depthOfField;
    private float startFocusDistance = 10f;
    private float endFocusDistance = 2.6f;

    private void Start()
    {
        // PostProcessing setup remains the same

        AnimationIsDone = false;
        reverseAnimation = false;
        // Get Target Position
        GameObject targetCamera = GameObject.Find("FinalPositionOfCamera");
        targetTransform = targetCamera.transform;
        // Store the start position and rotation
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void ActivateCameraAnimation(bool _reverseAnimation)
    {
        reverseAnimation = _reverseAnimation;

        // Adjust the positions and transforms based on the flag
        if (reverseAnimation)
        {
            // Swap start and target positions and rotations
            Vector3 tempPosition = startPosition;
            startPosition = targetTransform.position;
            targetTransform.position = tempPosition;

            Quaternion tempRotation = startRotation;
            startRotation = targetTransform.rotation;
            targetTransform.rotation = tempRotation;

            // Reset time and animation state
            elapsedTime = 0f;
            AnimationIsDone = false;
        }

        StartAnimation = true;
    }

    void Update()
    {   
        if (StartAnimation) 
        {
            if (elapsedTime < transitionTime)
            {
                // Calculate the fraction of the journey completed
                float fraction = elapsedTime / transitionTime;

                // Interpolate position and rotation
                transform.position = Vector3.Lerp(startPosition, targetTransform.position, fraction);
                transform.rotation = Quaternion.Slerp(startRotation, targetTransform.rotation, fraction);

                // Increment the time elapsed
                elapsedTime += Time.deltaTime;

                if (depthOfField != null)
                {
                    // Example: Adjust the focus distance and aperture over time
                    depthOfField.focusDistance.value = Mathf.Lerp(startFocusDistance, endFocusDistance, elapsedTime / transitionTime);
                }
            }
            else 
            {
                AnimationIsDone = true;
                StartAnimation = false;
            }
        }
    }


    public static explicit operator ScriptableObject(Pet_CameraIntro v)
    {
        throw new NotImplementedException();
    }
}
