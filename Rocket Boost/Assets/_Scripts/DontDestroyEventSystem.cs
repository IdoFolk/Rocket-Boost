using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyEventSystem : MonoBehaviour
{
    public static DontDestroyEventSystem instance;
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
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


}
