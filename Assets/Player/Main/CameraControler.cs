using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float speed = 100;
    public Transform playerbody;
    float xr = 0;

    void Awake()
    {

        Cursor.lockState = CursorLockMode.Locked;

    }


    void Update()

    {

        float mx = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float my = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        xr -= my;
        playerbody.Rotate(Vector3.up * mx);
        xr = Mathf.Clamp(xr, -90, 90);
        transform.localRotation = Quaternion.Euler(xr, 0, 0);






    }







}
