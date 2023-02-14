using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool musicOn = true;
    public static bool sfxOn = true;
    public static bool GamePaused;


    public int currentHP { get; private set; }
    [Header("Life")]
    [SerializeField] int maxHP;

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
        currentHP = maxHP;
    }

    void Update()
    {
        PauseMenu();
    }
    public void LoseOneLife()
    {
        currentHP--;
        if (currentHP == 0) RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ActivateBackgroundMusicDelay()
    {
        Invoke("ActivateBackgroundMusic", 0.1f);
    }
    private void ActivateBackgroundMusic()
    {
        GameAudioManager.instance.gameObject.SetActive(true);
    }
    private void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!DontDestroyPauseMenu.instance.gameObject.activeSelf)
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
