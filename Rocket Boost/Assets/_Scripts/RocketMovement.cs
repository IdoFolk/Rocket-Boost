using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotationPower = 100f;
    [SerializeField] AudioClip thrustSound;
    [SerializeField] AudioClip sideThrustSound;
    [SerializeField] ParticleSystem mainThrustEffect;
    [SerializeField] ParticleSystem rightThrustEffect;
    [SerializeField] ParticleSystem leftThrustEffect;

    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource audioSource;

    private bool leftPressed;
    private bool rightPressed;
    private bool spacePressed;


    private void Update()
    {
        HandleInput();
    }
    private void FixedUpdate()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftPressed = true;
        }
        else
        {
            leftPressed = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightPressed = true;
        }
        else
        {
            rightPressed = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            spacePressed = true;
        }
        else
        {
            spacePressed = false;
        }
    }
    private void HandleRotation()
    {
        if (leftPressed)
        {
            if (!audioSource.isPlaying) audioSource.PlayOneShot(sideThrustSound);
            if (!rightThrustEffect.isPlaying) rightThrustEffect.Play();
            ApplyRotation(rotationPower);
        }
        if (rightPressed)
        {
            if (!audioSource.isPlaying) audioSource.PlayOneShot(sideThrustSound);
            if (!leftThrustEffect.isPlaying) leftThrustEffect.Play();
            ApplyRotation(-rotationPower);
        }
        if (!leftPressed && !rightPressed)
        {
            if (!spacePressed) audioSource.Stop();
            rightThrustEffect.Stop();
            leftThrustEffect.Stop();
        }
    }
    private void HandleThrust()
    {
        if (spacePressed)
        {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.fixedDeltaTime);
            if (!audioSource.isPlaying) audioSource.PlayOneShot(thrustSound);
            if (!mainThrustEffect.isPlaying) mainThrustEffect.Play();
        }
        if (!spacePressed)
        {
            if (!leftPressed && !rightPressed) audioSource.Stop();
            mainThrustEffect.Stop();
        }
    }
    private void ApplyRotation(float rotationForce)
    {
        transform.Rotate(Vector3.forward * rotationForce * Time.fixedDeltaTime);
    }
}
