using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColide : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerDeadCamera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player is Dead");
            PlayerDeadFunctio();
        }
    }
    public void PlayerDeadFunctio()
    {
        PlayerDeadCamera.SetActive(true);
        Player.SetActive(false);

        Debug.Log("Player is Dead");
    }
}

