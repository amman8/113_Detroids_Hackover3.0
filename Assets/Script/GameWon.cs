using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public GameObject Player;
    public GameObject EndScreen;

    private void Awake()
    {
        EndScreen.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            EndScreen.SetActive(true);
            Player.SetActive(false);
            
        }
    }
}
