using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAudioManager : MonoBehaviour
{
    [SerializeField] GameObject endingMusic;
    [SerializeField] GameObject endingSFX;
    private void Start()
    {
        CheckAudio();
    }
    public void CheckAudio()
    {
        if (GameManager.instance.musicOn)
        {
            endingMusic.SetActive(true);
        }
        else
        {
            endingMusic.SetActive(false);
        }

        if (GameManager.instance.sfxOn)
        {
            endingSFX.SetActive(true);
        }
        else
        {
            endingSFX.SetActive(false);
        }
    }
}
