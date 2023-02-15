using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu instance;
    const string DROPS_TIMER_PATTERN = "{0:D2}:{1:D2}";

    [SerializeField] TextMeshProUGUI levelsText;
    [SerializeField] TextMeshProUGUI timePassedText;
    [SerializeField] AudioSource buttonClickSFX;
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
        gameObject.SetActive(false);
    }
    public void GetStats()
    {
        levelsText.text = GameManager.instance.LevelsCompleted.ToString();
        int timePassedMinutesText = GameManager.instance.TimePassedMinutes;
        int timePassedSecondsText = GameManager.instance.TimePassedSeconds;
        string timerText = string.Format(DROPS_TIMER_PATTERN, timePassedMinutesText, timePassedSecondsText);
        timePassedText.text = timerText;

    }
    public void RestartGame()
    {
        GameManager.instance.ResetStats();
        SceneManager.LoadScene(1);
        HudManager.instance.CheckLives();
        gameObject.SetActive(false);
        GameManager.instance.timerActive = true;
        GameManager.instance.GamePaused = false;
        Time.timeScale = 1;
    }
    public void PlayClickSFX()
    {
        buttonClickSFX.Stop();
        buttonClickSFX.Play();
    }

}
