using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        if (optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
        }
        Debug.Log("Pressed!");
    }

    public void OptionsMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        Debug.Log("Pressed!");
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Pressed!");
    }

    private void QuitGame()
    { 
        
    }

    private void LoadGameMenu()
    { 
        
    }
}
