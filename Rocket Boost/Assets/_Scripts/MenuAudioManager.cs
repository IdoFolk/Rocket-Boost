using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioManager : MonoBehaviour
{
    public static MenuAudioManager instance;

    [SerializeField] AudioSource menuMusic;
    [SerializeField] AudioSource menuSFX;
    [SerializeField] float menuMusicVolume;
    [SerializeField] float menuSFXVolume;
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
    }
    public void ToggleMusicMenu()
    {
        if (GameManager.musicOn)
        {
            menuMusic.volume = 0;
            GameManager.musicOn = false;
        }
        else
        {
            menuMusic.volume = menuMusicVolume;
            GameManager.musicOn = true;
        }
    }
    public void ToggleSFXMenu()
    {
        if (GameManager.sfxOn)
        {
            menuSFX.volume = 0;
            GameManager.sfxOn = false;
        }
        else
        {
            menuSFX.volume = menuSFXVolume;
            GameManager.sfxOn = true;
        }
    }
    public void CheckAudio()
    {
        if (GameManager.musicOn)
        {
            menuMusic.volume = menuMusicVolume;
        }
        else
        {
            menuMusic.volume = 0;
        }

        if (GameManager.sfxOn)
        {
            menuSFX.volume = menuSFXVolume;
        }
        else
        {
            menuSFX.volume = 0;
        }
    }
}
