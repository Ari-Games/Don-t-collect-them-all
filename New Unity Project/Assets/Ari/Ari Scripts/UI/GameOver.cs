using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ToExit()
    {
        Time.timeScale = 1;
        GWorld.Reset();
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        GWorld.Reset();
        SceneManager.LoadScene(2);
    }

}
