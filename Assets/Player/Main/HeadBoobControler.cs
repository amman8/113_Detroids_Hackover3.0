using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBoobControler : MonoBehaviour
{
    [Header("Transform references")]
    public Transform headTransform;
    public Transform cameraTransform;
    [Header("Head bobbing")]
    public float bobFrequency = 5f;
    public float bobHorizonalAmplitude = 0.1f;
    public float bobVerticalAmplitude = 0.1f;
    [Range(0, 1)] public float headBobSmoothing = 0.1f;

    // State
    public bool isWalking;
    private float walkingTime;
    private Vector3 targetCameraPosition;

    private void Update()
    {
        if (!isWalking) walkingTime = 0;
        else walkingTime += Time.deltaTime;
        targetCameraPosition = headTransform.position + CalculateHeadBobOffset(walkingTime);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetCameraPosition, headBobSmoothing);
        if ((cameraTransform.position - targetCameraPosition).magnitude < 0.001)
            cameraTransform.position = targetCameraPosition;
    }

    private Vector3 CalculateHeadBobOffset(float t)
    {
        float horizontal0ffset = 0;
        float vertical0ffset = 0;
        Vector3 offset = Vector3.zero;
        if (t > 0)
        {
            // Calculate offsets
            horizontal0ffset = Mathf.Cos(t * bobFrequency) * bobHorizonalAmplitude;
            vertical0ffset = Mathf.Sin(t * bobFrequency * 2) * bobVerticalAmplitude;
            // Combine offsets relative to the head's position and calculate the camera's target position
            offset = headTransform.right * horizontal0ffset + headTransform.up * vertical0ffset;

        }
        return offset;
    }
}
