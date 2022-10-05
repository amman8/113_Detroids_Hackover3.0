using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float speed = 100;
    public Transform playerbody;
    float xr = 0;

    public PlayerMovement s_pmms;

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
        if(s_pmms.isMenuOn == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if(s_pmms.isMenuOn == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        





    }







}
