using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public bool isTransitioning;

    [Header("General")]
    [SerializeField] float respawnDelay = 1f;
    [SerializeField] float finishDelay = 1f;
    [SerializeField] RocketMovement rocketMovement;
    [SerializeField] HudManager hudManager;

    [Header("Particle")]
    [SerializeField] ParticleSystem crashParticleEffect;
    [SerializeField] ParticleSystem finishParticleEffect;

    [Header("Audio")]
    [SerializeField] AudioSource generalAudioSource;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip finishSound;
    [SerializeField] AudioClip fuelCapsuleSound;
    [SerializeField] AudioClip lowFuelSound;
    
    private bool collisionDisabled;
    private void Start()
    {
        hudManager = HudManager.instance;
        generalAudioSource = GameAudioManager.instance.generalAudioSource;
    }
    private void Update()
    {
        CheatCodes();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || collisionDisabled) return;
        switch (collision.gameObject.tag)
        {
            case "Start":
                break;
            case "Finish":
                FinishLevel();
                break;
            default:
                RocketCrash();
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                GetFuelCapsule(other);
                break;
        }

    }
    public void PlayLowFuelSFX()
    {
        if (!generalAudioSource.isPlaying && !GameManager.instance.GamePaused)
        {
            generalAudioSource.PlayOneShot(lowFuelSound);
        }
    }
    
    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    private void RocketCrash()
    {
        rocketMovement.StopAllEffectsAndSounds();
        generalAudioSource.Stop();
        isTransitioning = true;
        generalAudioSource.PlayOneShot(crashSound);
        crashParticleEffect.Play();
        Invoke("Respawn", respawnDelay);
    }
    private void Respawn()
    {
        GameManager.instance.LoseOneLife();
        hudManager.CheckLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void FinishLevel()
    {
        GameManager.instance.LevelsCompleted++;
        generalAudioSource.Stop();
        isTransitioning = true;
        generalAudioSource.PlayOneShot(finishSound);
        finishParticleEffect.Play();
        Invoke("NextLevel", finishDelay);
    }
    private void GetFuelCapsule(Collider other)
    {
        generalAudioSource.Stop();
        generalAudioSource.PlayOneShot(fuelCapsuleSound);
        rocketMovement.AddFuel();
        other.gameObject.SetActive(false);
    }
    private void CheatCodes()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            Respawn();
        }
    }
}
