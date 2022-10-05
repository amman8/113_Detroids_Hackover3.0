using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public PlayerMovement s_PMS;
    public AudioSource Button;
    public GameObject LevelChoose;
    

    public void PlayOnMainMenu()
    {
        Button.Play();
        LevelChoose.SetActive(true);
    }

    public void Level1()
    {
        Button.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitButtonPauseMenu()
    {
        Button.Play();
        SceneManager.LoadScene(0);
    }

    public void QuitButtonMainMenu()
    {
        Button.Play();
        Application.Quit();
    }
    public void ResumeMenu()
    {
        Button.Play();
        s_PMS.isMenuOn =! s_PMS.isMenuOn;
    }    
}
