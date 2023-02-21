using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour
{
    public void BackToMainMenu()
    {
        MenuAudioManager.instance.gameObject.SetActive(true);
        MainMenu.instance.gameObject.SetActive(true);
        MainMenu.instance.CheckAudio();
        SceneManager.LoadScene(0);
    }
}
