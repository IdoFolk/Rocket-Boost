using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool MusicOn;
    public static bool SFXOn;

    [SerializeField] GameObject pauseMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenu();
    }

    private void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
    private void CheckMusic()
    {
        if (MusicOn)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneAt(0))
            {

            }
        }
    }
    private void CheckSFX()
    {

    }
}
