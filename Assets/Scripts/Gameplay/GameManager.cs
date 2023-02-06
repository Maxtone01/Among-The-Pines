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

    public void Start()
    {
        Instance = this;
        SettingsInitialization();
    }

    public void SettingsInitialization()
    {
        defaultCamSpeed = 2;
    }
    //public void Start()
    //{
    //    SetGameConfiguration();
    //}

    //private void SetGameConfiguration()
    //{
    //    throw new NotImplementedException();
    //}
    //bool gameHasEnded = false;

    //public void GameOver()
    //{
    //    if (gameHasEnded == false)
    //    { 
    //        gameHasEnded = true;
    //        Invoke("Restart", 2f);
    //    }
    //}

    //public void Restart()
    //{ 
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
