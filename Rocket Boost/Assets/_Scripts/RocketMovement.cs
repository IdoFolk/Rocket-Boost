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

    Rigidbody rb;
    AudioSource audioSource;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        HandleRotation();
        HandleThrust();
    }
    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!audioSource.isPlaying) audioSource.PlayOneShot(sideThrustSound);
            if (!rightThrustEffect.isPlaying) rightThrustEffect.Play();
            ApplyRotation(rotationPower);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!audioSource.isPlaying) audioSource.PlayOneShot(sideThrustSound);
            if (!leftThrustEffect.isPlaying) leftThrustEffect.Play();
            ApplyRotation(-rotationPower);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            audioSource.Stop();
            rightThrustEffect.Stop();
            leftThrustEffect.Stop();
        }
    }
    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
            if (!audioSource.isPlaying) audioSource.PlayOneShot(thrustSound);
            if (!mainThrustEffect.isPlaying) mainThrustEffect.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.Stop();
            mainThrustEffect.Stop();
        }
    }
    private void ApplyRotation(float rotationForce)
    {
        //rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationForce * Time.deltaTime);
        //rb.freezeRotation = false;
    }
}
