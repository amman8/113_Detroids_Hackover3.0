using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour
{


    public Camera Camera;
    float targetFOV;
    float fov;


    void Awake()
    {
        targetFOV = Camera.fieldOfView;
        fov = targetFOV;
    }

    // Update is called once per frame
    void Update()
    {
        float fovSpeed = 4f;
        fov = Mathf.Lerp(fov, targetFOV, Time.deltaTime * fovSpeed);
        Camera.fieldOfView = fov;
    }

    public void SetCameraFOV(float targetFOV)
    {
        this.targetFOV = targetFOV;
    }
}
