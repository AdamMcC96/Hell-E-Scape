using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainscreen, aboutscreen;
    public void OnBtnPlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnBtnAbout()
    {
        mainscreen.SetActive(false);
        aboutscreen.SetActive(true);
    }
    public void OnBtnBack()
    {
        mainscreen.SetActive(true);
        aboutscreen.SetActive(false);
    }
    public void OnBtnQuit()
    {
        Application.Quit();
    }
}
 
