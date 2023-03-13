using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [Header("GameSettings")]
    public float defaultCamSpeed;
    public float defaultResolution;
    private ConversantController conversantController;
    [SerializeField] GameObject cameraState;
    MovementScript moveScript;
    Animator animator;

    private void Awake()
    {
        Cursor.visible = false;
    }

    public void Start()
    {
        Instance = this;
        SettingsInitialization();
        conversantController = GameObject.FindGameObjectWithTag("Player").GetComponent<ConversantController>();
        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public void MouseState(States.GameStates action)
    {
        switch (action)
        {
            case States.GameStates.Enter_Dialogue:
                Cursor.visible = true;
                cameraState.SetActive(false);
                moveScript.enabled = false;
                animator.SetFloat("State", 0);
                break;

            case States.GameStates.Exit_Dialogue:
                Cursor.visible = false;
                cameraState.SetActive(true);
                moveScript._movementForce = 5f;
                moveScript.enabled = true;
                break;
        }
    }

    public void SettingsInitialization()
    {
        defaultCamSpeed = 2;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
