using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] GameObject backgroundMusic;
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuCanvas.SetActive(false);
    }
    public void BackToMainMenu()
    {
        Destroy(backgroundMusic);
        SceneManager.LoadScene(0);
    }

}
