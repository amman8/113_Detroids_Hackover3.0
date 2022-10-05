using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColide : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerDeadCamera;
    public PlayerMovement pms;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    public CountDown cd;


    public GameObject GameLostText;
    private void Update()
    {
        if (cd.curenttime < 0.5f)
        {
            //Debug.Log(cd.curenttime);
            PlayerDeadFunctio();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player is Dead");
            pms.PlayerHealth--;
            if(pms.PlayerHealth==2)
            {
                Heart3.SetActive(false);
            }
            if (pms.PlayerHealth == 1)
            {
                Heart2.SetActive(false);
            }

            if (pms.PlayerHealth == 0)
            {
                PlayerDeadFunctio();
            }
            
            
        }
        

    }
    public void PlayerDeadFunctio()
    {
        PlayerDeadCamera.SetActive(true);
        Player.SetActive(false);
        GameLostText.SetActive(true);
        //Debug.Log("Player is Dead");
    }
}

