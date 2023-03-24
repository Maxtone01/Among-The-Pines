using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("GameState")]
    public bool gameIsPaused = false;

    [Header("PauseMenus")]
    public GameObject pauseMenuUI;
    public GameObject pauseMenu;
    public GameObject optionsMenuUI;
    public GameObject optionsMenu;
    public GameObject videoSettings;
    public GameObject controlsSettings;
    private GameObject dialogueController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueController = GameObject.FindGameObjectWithTag("Dialogue Panel");
            if (dialogueController == null & !gameIsPaused)
            {
                PauseGame();
            }
            else if (!gameIsPaused)
            {
                DialogueUI dialogue = dialogueController.GetComponent<DialogueUI>();
                dialogue.conversantController.QuitDialogue();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
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
            pauseMenuUI.SetActive(true);
        }
    }

    public void OptionsMenu()
    {
        pauseMenuUI.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Controls()
    {
        optionsMenuUI.SetActive(false);
        controlsSettings.SetActive(true);
    }

    public void VideoSettings()
    {
        optionsMenuUI.SetActive(false);
        videoSettings.SetActive(true);
    }

    private void QuitGame()
    { 
        
    }

    private void LoadGameMenu()
    { 
        
    }
}
