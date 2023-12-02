using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Pet_CameraIntro : MonoBehaviour
{
    public Transform targetTransform; // Assign the target transform in the inspector
    private Vector3 startPosition;
    private Quaternion startRotation;
    private float transitionTime = 3.0f; // Duration of the transition in seconds
    private float elapsedTime = 0.0f;
    public bool AnimationIsDone;
    private bool StartAnimation = false;

    // Post Processing
    public PostProcessVolume postProcessVolume;
    private DepthOfField depthOfField;
    private float startFocusDistance = 10f;
    private float endFocusDistance = 2.6f;

    public void ActivateCameraAnimation()
    {
        StartAnimation = true;
    }
    void Start()
    {
        // PostProcessing
        postProcessVolume = GameObject.Find("PostProcessing").GetComponent<PostProcessVolume>();
        depthOfField = postProcessVolume.profile.GetSetting<DepthOfField>();

        AnimationIsDone = false;
        // Get Target Position
        GameObject targetCamera = GameObject.Find("FinalPositionOfCamera");
        targetTransform = targetCamera.transform;
        // Store the start position and rotation
        startPosition = transform.position;
        startRotation = transform.rotation;
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
            }
        }
    }
}
