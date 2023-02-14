using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Slider fuelBar;

    [SerializeField] Image leftControlButton;
    [SerializeField] Image rightControlButton;
    [SerializeField] Image upControlButton;
    [SerializeField] Image[] lives;

    private Color defaultColor;
    private void Start()
    {
        CheckLives();
        defaultColor = leftControlButton.color;
    }
    public void CheckLives()
    {
        int currentHP = GameManager.instance.currentHP;
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
