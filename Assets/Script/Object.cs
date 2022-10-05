using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Object : MonoBehaviour
{
    public PlayerMovement pm;
    public GameObject Itself;
    [SerializeField] TextMeshProUGUI SpeedText;
    [SerializeField] TextMeshProUGUI PlayerSeedCount;
    public AudioSource PickedAudio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            PickedAudio.Play();
            pm.maxGrapableDistance -= 10f;
            pm.hookshootSpeed -= 10f;
            pm.speed -= 2f;
            pm.jumpHeight -= 1f;
            Destroy(Itself);
            pm.currentSpeed -= 10f;
            SpeedText.text = pm.currentSpeed.ToString("0");
            pm.seedcount += 1f;
            PlayerSeedCount.text = pm.seedcount.ToString("0");
        }
    }
}
