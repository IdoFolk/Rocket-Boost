using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    public static HudManager instance;

    const string DROPS_TIMER_PATTERN = "{0:D2}:{1:D2}";

    public Slider fuelBar;

    [SerializeField] TextMeshProUGUI timerUI;
    [SerializeField] Image leftControlButton;
    [SerializeField] Image rightControlButton;
    [SerializeField] Image upControlButton;
    [SerializeField] Image[] lives;

    private Color defaultColor;
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
        CheckLives();
        defaultColor = leftControlButton.color;
    }
    private void Update()
    {
        timerUI.text = string.Format(DROPS_TIMER_PATTERN, GameManager.instance.TimePassedMinutes, GameManager.instance.TimePassedSeconds);
    }
    public void CheckLives()
    {
        int currentHP = GameManager.instance.CurrentHP;
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < currentHP) lives[i].gameObject.SetActive(true);
            else lives[i].gameObject.SetActive(false);
        }
    }
    public void PressedLeftControlButtonColor()
    {
        leftControlButton.color = Color.cyan;
    }
    public void PressedRightControlButtonColor()
    {
        rightControlButton.color = Color.cyan;
    }
    public void PressedUpControlButtonColor()
    {
        upControlButton.color = Color.cyan;
    }
    public void UnPressedLeftControlButtonColor()
    {
        leftControlButton.color = defaultColor;
    }
    public void UnPressedRightControlButtonColor()
    {
        rightControlButton.color = defaultColor;
    }
    public void UnPressedUpControlButtonColor()
    {
        upControlButton.color = defaultColor;
    }
    
}
