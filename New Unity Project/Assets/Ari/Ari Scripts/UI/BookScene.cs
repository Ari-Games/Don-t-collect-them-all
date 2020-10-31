using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookScene : MonoBehaviour
{
    public void OnApply()
    {
        SceneManager.LoadScene(2);
    }
}
