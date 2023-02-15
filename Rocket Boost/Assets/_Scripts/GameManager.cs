using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool musicOn = true;
    public bool sfxOn = true;
    public bool GamePaused;

    //Lives:
    public int CurrentHP { get; private set; }
    private int maxHP = 5;

    //Stats:
    public int LevelsCompleted;
    public int TimePassedMinutes;
    public int TimePassedSeconds;
    public bool timerActive;
    public float timer; // temp

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        CurrentHP = maxHP;
    }

    void Update()
    {
        Timer();
        PauseMenu();
    }
    public void LoseOneLife()
    {
        CurrentHP--;
        if (CurrentHP == 0) YouLostScreen();
    }
    public void ResetStats()
    {
        CurrentHP = maxHP;
        LevelsCompleted = 0;
        TimePassedSeconds = 0;
        TimePassedMinutes = 0;
        timerActive = false;
        timer = 0;
    }
    public void ActivateManagersDelay()
    {
        Invoke("ActivateManagers", 0.1f);
    }
    private void Timer()
    {
        if (timerActive && !GamePaused)
        {
            timer += Time.deltaTime;
            TimePassedMinutes = (int)timer / 60;
            TimePassedSeconds = (int)timer % 60;
        }
    }
    private void YouLostScreen()
    {
        GameOverMenu.instance.GetStats();
        GameOverMenu.instance.gameObject.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }
    private void ActivateManagers()
    {
        GameAudioManager.instance.gameObject.SetActive(true);
        HudManager.instance.gameObject.SetActive(true);
        HudManager.instance.CheckLives();
    }
    private void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GamePaused)
        {
            if (!DontDestroyPauseMenu.instance.gameObject.activeSelf && !GameOverMenu.instance.gameObject.activeSelf)
            {
                GameAudioManager.instance.StopSFX();
                Time.timeScale = 0;
                DontDestroyPauseMenu.instance.gameObject.SetActive(true);
                GamePaused = true;
            }
            else
            {
                Time.timeScale = 1;
                DontDestroyPauseMenu.instance.gameObject.SetActive(false);
                GamePaused = false;
            }
        }
    }
    
}
