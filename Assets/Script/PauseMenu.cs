using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public PlayerMovement s_PMS;
    public GameObject LevelChoose;
    

    public void PlayOnMainMenu()
    {
        s_PMS.ButtonClickAudio.Play();
        LevelChoose.SetActive(true);
    }

    public void Level1()
    {
        s_PMS.ButtonClickAudio.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitButtonPauseMenu()
    {
        s_PMS.ButtonClickAudio.Play();
        SceneManager.LoadScene(0);
    }

    public void QuitButtonMainMenu()
    {
        s_PMS.ButtonClickAudio.Play();
        Application.Quit();
    }
    public void ResumeMenu()
    {
        s_PMS.ButtonClickAudio.Play();
        s_PMS.isMenuOn =! s_PMS.isMenuOn;
    }    
}
