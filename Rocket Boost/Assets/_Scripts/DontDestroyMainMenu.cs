using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMainMenu : MonoBehaviour
{
    public static DontDestroyMainMenu instance;
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
    public void EnableMenu()
    {
        gameObject.SetActive(true);
    }
    public void DisableMenu()
    {
        gameObject.SetActive(false);
    }
}
