using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasUIScripts : MonoBehaviour
{
    private static bool GameIsPaused;
    public static CanvasUIScripts _instance;

    [SerializeField]
    private GameObject pauseMenuUI;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject OptionsMenuUI;

    void OnEnable()
    {
        
        GameObject.FindWithTag("UI").GetComponent<InputSystemKeyboard>().OnPause += GamePaused;

    }

    void OnDisable()
    {
   
        GameObject.FindWithTag("UI").GetComponent<InputSystemKeyboard>().OnPause += GamePaused;

    }

    void Start()
    {
        GameIsPaused = false;
    }

    //PauseMenu
    void GamePaused()
    {
        if (GameIsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        GameIsPaused = true;
    }


    //GameOverMenu
    public void GameOver()
    {
        if(!HealthSystem.died)
        {
            gameOver.SetActive(true);
        }
        

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

   
    }
}
