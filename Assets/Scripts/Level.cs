using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [Header("End Game")]
    [SerializeField] float delayInSeconds = 2f;

    [Header("Time")]
    [SerializeField] bool TimeLevel;
    [SerializeField] float TimeSeconds = 1f;

    void Update()
    {
        TimeCounter();
    }

    private void TimeCounter()
    {
        if (TimeLevel)
        {
            TimeSeconds -= Time.deltaTime;
            if (TimeSeconds <= 0)
            {
                LoadNextGame();
            }
        }
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level 1");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadNextGame()
    {
        StartCoroutine(LoadNextGameTime());
    }

    public void LoadFreeplay()
    {
        SceneManager.LoadScene("Freeplay Level Select Screen");
    }

    public void LoadFreeplayLV2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadFreeplayLV3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadFreeplayLV4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LoadFreeplayLV5()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void LoadFreeplayLV6()
    {
        SceneManager.LoadScene("Level 6");
    }

    public void LoadFreeplayLV7()
    {
        SceneManager.LoadScene("Level 7");
    }

    public void LoadFreeplayLV8()
    {
        SceneManager.LoadScene("Level 8");
    }

    public void LoadFreeplayLV9()
    {
        SceneManager.LoadScene("Level 9");
    }

    public void LoadFreeplayLV10()
    {
        SceneManager.LoadScene("Level 10");
    }

    public void LoadVictoryStory()
    {
        SceneManager.LoadScene("Level Win Screen(Story)");
    }

    public void LoadVictoryFreePlay()
    {
        SceneManager.LoadScene("Level Win Screen(FreePlay)");
    }

    public void LoadGameOverStory()
    {
        StartCoroutine(WaitAndLoadRealGame());
    }

    IEnumerator WaitAndLoadRealGame()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over Screen (Story)");
    }

    IEnumerator WaitAndLoadFreePlay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over Screen (Freeplay)");
    }

    IEnumerator LoadNextGameTime()
    {
        yield return new WaitForSeconds(delayInSeconds);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
