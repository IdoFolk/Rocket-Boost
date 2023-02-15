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
        if (GameManager.instance.musicOn)
        {
            menuMusic.volume = 0;
            GameManager.instance.musicOn = false;
        }
        else
        {
            menuMusic.volume = menuMusicVolume;
            GameManager.instance.musicOn = true;
        }
    }
    public void ToggleSFXMenu()
    {
        if (GameManager.instance.sfxOn)
        {
            menuSFX.volume = 0;
            GameManager.instance.sfxOn = false;
        }
        else
        {
            menuSFX.volume = menuSFXVolume;
            GameManager.instance.sfxOn = true;
        }
    }
    public void CheckAudio()
    {
        if (GameManager.instance.musicOn)
        {
            menuMusic.volume = menuMusicVolume;
        }
        else
        {
            menuMusic.volume = 0;
        }

        if (GameManager.instance.sfxOn)
        {
            menuSFX.volume = menuSFXVolume;
        }
        else
        {
            menuSFX.volume = 0;
        }
    }
}
