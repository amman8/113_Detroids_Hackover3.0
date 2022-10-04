using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public PlayerMovement pm;
    public GameObject Itself;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pm.maxGrapableDistance -= 10f;
            pm.hookshootSpeed -= 10f;
            pm.speed -= 2f;
            pm.jumpHeight -= 1f;
            Destroy(Itself);
        }
    }
}
