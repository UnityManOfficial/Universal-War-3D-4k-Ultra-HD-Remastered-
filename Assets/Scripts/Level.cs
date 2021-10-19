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
    [SerializeField] float TimeMinutes = 1f;

    [Header("Enemies")]
    [SerializeField] bool EnemiesLevel;
    [SerializeField] float EnemiesToTakeDown = 1f;

    void Update()
    {

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
