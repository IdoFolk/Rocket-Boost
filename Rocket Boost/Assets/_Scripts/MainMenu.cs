using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource buttonClickSFX;

    [SerializeField] GameObject musicButtonToggleOn;
    [SerializeField] GameObject musicButtonToggleOff;
    [SerializeField] GameObject sfxButtonToggleOn;
    [SerializeField] GameObject sfxButtonToggleOff;

    private void OnEnable()
    {
        CheckAudio();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        MenuAudioManager.instance.gameObject.SetActive(false);
        DontDestroyMainMenu.instance.gameObject.SetActive(false);
        GameManager.instance.ActivateBackgroundMusicDelay();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayClickSFX()
    {
        buttonClickSFX.Stop();
        buttonClickSFX.Play();
    }
    private void CheckAudio()
    {
        if (GameManager.musicOn)
        {
            musicButtonToggleOn.SetActive(true);
            musicButtonToggleOff.SetActive(false);
        }
        else
        {
            musicButtonToggleOn.SetActive(false);
            musicButtonToggleOff.SetActive(true);
        }
        if (GameManager.sfxOn)
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
