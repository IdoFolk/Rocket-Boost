using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static bool musicOn;
    public static bool sfxOn;

    private void Update()
    {
        CheckMusic();
    }

    private void CheckMusic()
    {
        if (musicOn)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneAt(0))
            {

            }
            else
            {

            }
        }
    }
}
