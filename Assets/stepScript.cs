using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;

public class stepScript : MonoBehaviour
{
    public collision getPlayerState;
    public GameObject stepPrefab;
    public GameObject nextStep;
    public Vector3[] stepPosition;

    public int numberOfSteps = 200;
    public float levelWidth = 6f;
    public float distanceX = 1f;
    public float distanceY = 1f;

   

    void Start()
    {
        
        
    }

    void Update()
    {
        Vector3 spawnPosition = new Vector3(); //Vector 3 spawn position
        spawnPosition = GameObject.FindGameObjectWithTag("step").transform.position; //set initial spawn position to existing location
        int x = 0;
        while (getPlayerState.playerStateAlive == true) // player is still alive
        {
            for (int i = 0; i < 11; i++) //spawn 10 steps
            {
              //  while (getPlayerState.jumpCounter < 6)
                //{
                    spawnPosition.y += distanceY; // spawn platform above
                    spawnPosition.x = Random.Range(0, 2) * 2 - 1 + spawnPosition.x; //spawn platform either left or right
                    if (spawnPosition.x >= 3) //if spawn position is too right
                    {
                        spawnPosition.x = 0 - 2 + spawnPosition.x; //left of boundary
                        stepPosition = new Vector3[numberOfSteps];
                        nextStep = Instantiate(stepPrefab, spawnPosition, Quaternion.identity);
                        stepPosition[x] = spawnPosition;
                        x++;
                        spawnPosition = stepPosition[x - 1];
                    }
                    else if (spawnPosition.x <= -3) //if spawn position is too left
                    {
                        spawnPosition.x = 2 + spawnPosition.x; //right of boundary
                        stepPosition = new Vector3[numberOfSteps];
                        nextStep = Instantiate(stepPrefab, spawnPosition, Quaternion.identity);
                        stepPosition[x] = spawnPosition;
                        x++;
                        spawnPosition = stepPosition[x - 1];
                    }
                    else
                    {
                        stepPosition = new Vector3[numberOfSteps];
                        nextStep = Instantiate(stepPrefab, spawnPosition, Quaternion.identity);
                        stepPosition[x] = spawnPosition;
                        x++;
                        spawnPosition = stepPosition[x - 1];
                    }
                }
            //}
        }
    }
}