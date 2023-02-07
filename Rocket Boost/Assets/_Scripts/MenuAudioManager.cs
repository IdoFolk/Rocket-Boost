using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioManager : MonoBehaviour
{
    public static bool musicOn = true;
    public static bool sfxOn = true;

    [SerializeField] AudioSource menuMusic;
    [SerializeField] AudioSource menuSFX;
    [SerializeField] float menuMusicVolume;
    [SerializeField] float menuSFXVolume;
    private void Start()
    {
        musicOn = GameAudioManager.musicOn;
        sfxOn = GameAudioManager.sfxOn;
    }
    public void ToggleMusicMenu()
    {
        if (musicOn)
        {
            menuMusic.volume = 0;
            musicOn = false;
        }
        else
        {
            menuMusic.volume = menuMusicVolume;
            musicOn = true;
        }
    }
    public void ToggleSFXMenu()
    {
        if (sfxOn)
        {
            menuSFX.volume = 0;
            sfxOn = false;
        }
        else
        {
            menuSFX.volume = menuSFXVolume;
            sfxOn = true;
        }
    }
}
