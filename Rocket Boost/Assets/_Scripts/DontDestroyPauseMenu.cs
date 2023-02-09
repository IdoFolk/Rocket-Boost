using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPauseMenu : MonoBehaviour
{
    public static DontDestroyPauseMenu instance;
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
        gameObject.SetActive(false);
    }
    public void EnableMenu()
    {
        gameObject.SetActive(true);
    }
    public void DisableMenu()
    {
        gameObject.SetActive(false);
    }
}
