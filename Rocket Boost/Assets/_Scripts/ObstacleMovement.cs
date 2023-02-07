using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0,1)] float movementFactor;
    [SerializeField] float period;

    private Vector3 startingPos;
    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        MoveObstacle();
    }

    void MoveObstacle()
    {
        if (period != 0)
        {
            float cycles = Time.time / period; // represents the number of cycles that have happened according to the current time

            const float tau = Mathf.PI * 2; // constant value for tau
            float sinWave = Mathf.Sin(tau * cycles); // going from -1 to 1

            movementFactor = (sinWave + 1f) / 2f; // recalculated to go from 0 to 1 

            Vector3 offset = movementVector * movementFactor; // defines the vector that the object wil go to next
            transform.position = startingPos + offset; // move the object
        }
    }
} 
