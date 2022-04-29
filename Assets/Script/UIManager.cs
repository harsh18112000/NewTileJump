using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public StatManager gameStateManager;
    public Canvas mainMenu;
    public Canvas gamePlay;
    public Canvas gameOver;
    public ObjectPool objectPool;
    public Button TapToResume;
   
    


    public void OnEnable()
    {
        gameStateManager.GameMainMenu += ChangeToMainMenu;
        gameStateManager.GamePlay += ChangeToGamePlay;
        gameStateManager.GameOver += ChangeToGameOver;

    }

    public void Start()
    {
        instance = this;
    }    

    
    public void ChangeToMainMenu()
    {
        gamePlay.enabled = false;
        mainMenu.enabled = true;
        gameOver.enabled = false;
    }
    public void ChangeToGamePlay()
    {
        gamePlay.enabled = true;
        mainMenu.enabled = false;
        gameOver.enabled = false;
        TapToResume.gameObject.SetActive(false);
    }
    public void ChangeToGameOver()
    {
        gamePlay.enabled = false;
        mainMenu.enabled = false;
        gameOver.enabled = true;
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        TapToResume.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        TapToResume.gameObject.SetActive(false);
    }

    public void ReplayGame()
    {
        ChangeToGamePlay();
        objectPool.gameOver = false;

    }
}
