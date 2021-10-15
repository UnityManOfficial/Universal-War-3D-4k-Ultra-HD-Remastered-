using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    [SerializeField] int LevelNumber = 1;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void Selector()
    {
        SceneManager.LoadScene(LevelNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
