using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public GameObject Player;
    public GameObject EndScreen;
    public PlayerMovement s_playerscripty;
    public GameObject GameWonText;

    private void Awake()
    {
        EndScreen.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& s_playerscripty.seedcount >=3)
        {
            EndScreen.SetActive(true);
            Player.SetActive(false);
            GameWonText.SetActive(true);
            Invoke("NextCean",9f);
        }
        /*if(other.CompareTag("Player") && s_playerscripty.seedcount <= 3)
        {

        }*/
    }

    public void NextCean()
    {
        SceneManager.LoadScene(2);
    }
}
