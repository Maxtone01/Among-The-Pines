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
}
