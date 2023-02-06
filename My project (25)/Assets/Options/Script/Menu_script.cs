using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour
{
    public void Play_Game()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene(1);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
