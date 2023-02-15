using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager instance;

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
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        CheckAudio();
    }
    public void ToggleMusic()
    {
        if (GameManager.instance.musicOn)
        {
            foreach (var audioSource in musicAudioSource)
            {
                audioSource.volume = 0;
            }
            GameManager.instance.musicOn = false;
        }
        else
        {
            foreach (var audioSource in musicAudioSource)
            {
                audioSource.volume = gameMusicVolume;
            }
            GameManager.instance.musicOn = true;
        }
    }
    public void ToggleSFX()
    {
        if (GameManager.instance.sfxOn)
        {
            foreach (var audioSource in sfxAudioSource)
            {
                audioSource.volume = 0;
            }
            GameManager.instance.sfxOn = false;
        }
        else
        {
            foreach (var audioSource in sfxAudioSource)
            {
                audioSource.volume = gameSFXVolume;
            }
            GameManager.instance.sfxOn = true;
        }
    }
    public void StopSFX()
    {
        foreach (var audioSource in sfxAudioSource)
        {
            audioSource.Stop();
        }
    }
    public void CheckAudio()
    {
        if (GameManager.instance.musicOn)
        {
            foreach (var audioSource in musicAudioSource)
            {
                audioSource.volume = gameMusicVolume;
            }
        }
        else
        {
            foreach (var audioSource in musicAudioSource)
            {
                audioSource.volume = 0;
            }
        }

        if (GameManager.instance.sfxOn)
        {
            foreach (var audioSource in sfxAudioSource)
            {
                audioSource.volume = gameSFXVolume;
            }
        }
        else
        {
            foreach (var audioSource in sfxAudioSource)
            {
                audioSource.volume = 0;
            }
        }
    }
}
