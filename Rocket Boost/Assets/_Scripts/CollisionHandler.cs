using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float respawnDelay = 1f;
    [SerializeField] float finishDelay = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip finishSound;
    [SerializeField] ParticleSystem crashParticleEffect;
    [SerializeField] ParticleSystem finishParticleEffect;

    AudioSource audioSource;

    private bool isTransitioning;
    private bool collisionDisabled;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
    private void Respawn()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
            audioSource.Stop();
            isTransitioning = true;
            audioSource.PlayOneShot(crashSound);
            crashParticleEffect.Play();
            GetComponent<RocketMovement>().enabled = false;
            Invoke("Respawn", respawnDelay);
    }
    private void FinishLevel()
    {
            audioSource.Stop();
            isTransitioning = true;
            audioSource.PlayOneShot(finishSound);
            finishParticleEffect.Play();
            GetComponent<RocketMovement>().enabled = false;
            Invoke("NextLevel", finishDelay);
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
    }
}
