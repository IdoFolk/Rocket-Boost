using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    [SerializeField] AudioSource buttonClickSFX;

    [SerializeField] GameObject musicButtonToggleOn;
    [SerializeField] GameObject musicButtonToggleOff;
    [SerializeField] GameObject sfxButtonToggleOn;
    [SerializeField] GameObject sfxButtonToggleOff;
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
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        CheckAudio();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        MenuAudioManager.instance.gameObject.SetActive(false);
        gameObject.SetActive(false);
        GameManager.instance.ActivateManagersDelay();
        GameManager.instance.ResetStats();
        GameManager.instance.timerActive = true;
        
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
    public void CheckAudio()
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
