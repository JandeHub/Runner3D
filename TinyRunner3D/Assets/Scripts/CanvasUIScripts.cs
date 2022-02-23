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


    private HealthSystem _health;


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
   
        _health = GetComponent<HealthSystem>();
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
    void GameOver()
    {
        gameOver.SetActive(true);
        

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

   
    }
}
