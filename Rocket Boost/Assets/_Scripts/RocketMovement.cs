using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketMovement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] CollisionHandler collisionHandler;
    [SerializeField] HudManager hudManager;

    [Header("physics")]
    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotationPower = 100f;
    [SerializeField] Rigidbody rb;
    
    [Header("Particle")]
    [SerializeField] ParticleSystem mainThrustEffect;
    [SerializeField] ParticleSystem rightThrustEffect;
    [SerializeField] ParticleSystem leftThrustEffect;

    [Header("Audio")]
    [SerializeField] AudioSource mainThrusteraudioSource;
    [SerializeField] AudioSource sideThrusteraudioSource;

    [Header("Fuel")]
    [SerializeField] float fuelTank;
    [SerializeField] float fuelConsumption;
    [SerializeField] float fuelCapsulesValue;
    [SerializeField] float lowFuelDetectionRange;

    private float fuel;
    private bool leftPressed;
    private bool rightPressed;
    private bool spacePressed;
    private void Start()
    {
        hudManager.fuelBar.maxValue = fuelTank;
        mainThrusteraudioSource = GameAudioManager.instance.mainThrusterAudioSource;
        sideThrusteraudioSource = GameAudioManager.instance.sideThrusterAudioSource;
        fuel = fuelTank;
    }
    private void Update()
    {
        hudManager.fuelBar.value = fuel;
        HandleInput();
        LowFuelDetection();
    }
    private void FixedUpdate()
    {
            HandleRotation();
            HandleThrust();
    }
    public void AddFuel()
    {
        fuel += fuelCapsulesValue;
    }
    
    public void StopAllEffectsAndSounds()
    {
        sideThrusteraudioSource.Stop();
        mainThrusteraudioSource.Stop();
        rightThrustEffect.Stop();
        leftThrustEffect.Stop();
        mainThrustEffect.Stop();
    }
    private void LowFuelDetection()
    {
        if (fuel <= lowFuelDetectionRange)
        {
            collisionHandler.PlayLowFuelSFX();
        }
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            hudManager.PressedLeftControlButtonColor();
            leftPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            hudManager.UnPressedLeftControlButtonColor();
            leftPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            hudManager.PressedRightControlButtonColor();
            rightPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            hudManager.UnPressedRightControlButtonColor();
            rightPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hudManager.PressedUpControlButtonColor();
            spacePressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            hudManager.UnPressedUpControlButtonColor();
            spacePressed = false;
        }
    }
    private void HandleRotation()
    {
        if (leftPressed)
        {
            if (!sideThrusteraudioSource.isPlaying) sideThrusteraudioSource.Play();
            if (!rightThrustEffect.isPlaying) rightThrustEffect.Play();
            ApplyRotation(rotationPower);
        }
        if (rightPressed)
        {
            if (!sideThrusteraudioSource.isPlaying) sideThrusteraudioSource.Play();
            if (!leftThrustEffect.isPlaying) leftThrustEffect.Play();
            ApplyRotation(-rotationPower);
        }
        if (!leftPressed && !rightPressed)
        {
            sideThrusteraudioSource.Stop();
            rightThrustEffect.Stop();
            leftThrustEffect.Stop();
        }
    }
    private void HandleThrust()
    {
        if (spacePressed && fuel >= 0)
        {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.fixedDeltaTime);
            if (!mainThrusteraudioSource.isPlaying) mainThrusteraudioSource.Play();
            if (!mainThrustEffect.isPlaying) mainThrustEffect.Play();
            fuel -= fuelConsumption * Time.fixedDeltaTime; 
        }
        if (!spacePressed || fuel <= 0)
        {
            mainThrusteraudioSource.Stop();
            mainThrustEffect.Stop();
        }
    }
    private void ApplyRotation(float rotationForce)
    {
        transform.Rotate(Vector3.forward * rotationForce * Time.fixedDeltaTime);
    }
    
}
