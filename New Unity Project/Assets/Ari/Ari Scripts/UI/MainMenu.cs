using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitApplication()
    {
        Application.Quit();
    }

    public void GoToPlay()
    {
        Debug.Log(10);
        SceneManager.LoadScene(1);
    }
}
