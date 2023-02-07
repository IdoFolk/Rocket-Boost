using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager instance;
    public static bool musicOn = true;
    public static bool sfxOn = true;

    public AudioSource mainThrusterAudioSource;
    public AudioSource sideThrusterAudioSource;
    public AudioSource generalAudioSource;
    [SerializeField] AudioSource[] musicAudioSource;
    [SerializeField] AudioSource[] sfxAudioSource;
    [SerializeField] float gameMusicVolume;
    [SerializeField] float gameSFXVolume;
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
        musicOn = MenuAudioManager.musicOn;
        sfxOn = MenuAudioManager.sfxOn;
        DontDestroyOnLoad(gameObject);
    }
    public void ToggleMusicGame()
    {
        if (musicOn)
        {
            foreach (var audioSource in musicAudioSource)
            {
                audioSource.volume = 0;
            }
            musicOn = false;
        }
        else
        {
            foreach (var audioSource in musicAudioSource)
            {
                audioSource.volume = gameMusicVolume;
            }
            musicOn = true;
        }
    }
    public void ToggleSFXGame()
    {
        if (sfxOn)
        {
            foreach (var audioSource in sfxAudioSource)
            {
                audioSource.volume = 0;
            }
            sfxOn = false;
        }
        else
        {
            foreach (var audioSource in sfxAudioSource)
            {
                audioSource.volume = gameSFXVolume;
            }
            sfxOn = true;
        }
    }
}
