using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] GameObject gameAudioManager;
    [SerializeField] AudioSource buttonClickSFX;

    [SerializeField] GameObject musicButtonToggleOn;
    [SerializeField] GameObject musicButtonToggleOff;
    [SerializeField] GameObject sfxButtonToggleOn;
    [SerializeField] GameObject sfxButtonToggleOff;
    private void OnEnable()
    {
        CheckAudio();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuCanvas.SetActive(false);
        GameManager.instance.GamePaused = false;
    }
    public void BackToMainMenu()
    {
        GameManager.instance.GamePaused = false;
        Time.timeScale = 1;
        gameAudioManager.SetActive(false);
        pauseMenuCanvas.SetActive(false);
        HudManager.instance.gameObject.SetActive(false);
        MenuAudioManager.instance.gameObject.SetActive(true);
        MenuAudioManager.instance.CheckAudio();
        MainMenu.instance.gameObject.SetActive(true);
        MainMenu.instance.CheckAudio();
        SceneManager.LoadScene(0);
    }
    public void PlayClickSFX()
    {
        buttonClickSFX.Stop();
        buttonClickSFX.Play();
    }
    private void CheckAudio()
    {
        if (GameManager.instance.musicOn)
        {
            musicButtonToggleOn.SetActive(true);
            musicButtonToggleOff.SetActive(false);
        }
        else
        {
            musicButtonToggleOn.SetActive(false);
            musicButtonToggleOff.SetActive(true);
        }
        if (GameManager.instance.sfxOn)
        {
            sfxButtonToggleOn.SetActive(true);
            sfxButtonToggleOff.SetActive(false);
        }
        else
        {
            sfxButtonToggleOn.SetActive(false);
            sfxButtonToggleOff.SetActive(true);
        }
    }
}
