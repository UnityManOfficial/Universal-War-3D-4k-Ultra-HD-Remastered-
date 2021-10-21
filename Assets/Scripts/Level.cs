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

    [Header("Enemies")]
    [SerializeField] bool EnemiesLevel;
    [SerializeField] float EnemiesToTakeDown = 1f;

    void Update()
    {
        EnemiesCountDown();
        TimeCounter();
    }

    private void EnemiesCountDown()
    {
        GameObject theEnemies = GameObject.Find("Enemy Bomber");
        Enemy enemiescount = FindObjectOfType<Enemy>();
        if (!enemiescount) { return; }
        EnemyTaker(enemiescount);
    }

    private void EnemyTaker(Enemy enemiesCount)
    {
        if (EnemiesLevel)
        {
            EnemiesToTakeDown -= enemiesCount.CountDown();
            if (EnemiesToTakeDown <= 0)
            {
                LoadNextGame();
            }
        }
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
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
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

    public void LoadGameOverFreePlay()
    {
        StartCoroutine(WaitAndLoadFreePlay());
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
