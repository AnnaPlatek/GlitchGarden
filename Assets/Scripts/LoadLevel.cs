using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int timeToWait = 5;
    public Button startGameButton;
    public Button playAgainButton;
    
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }

        if (startGameButton)
        {
            startGameButton.onClick.AddListener(LoadNextLevel);
        }

        if (playAgainButton)
        {
            playAgainButton.onClick.AddListener(Restart);
        }
        
        
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void Restart()
    {
        //load Level 1 after click on "Play again" button
        SceneManager.LoadScene("Level1");
    }

    public void ReloadSameLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
