using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


    public void loadScene(string index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}