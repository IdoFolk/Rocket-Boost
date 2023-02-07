using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource buttonClickSFX;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
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
}
