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
        Vector3 spawnPosition = new Vector3();
        spawnPosition = GameObject.FindGameObjectWithTag("step").transform.position;
        int x = 0;
        while (getPlayerState.playerStateAlive == true)
        {

            spawnPosition.y += distanceY;
            spawnPosition.x = Random.Range(0, 2) * 2 - 1 + spawnPosition.x;
            if (spawnPosition.x >= 3)
            {
                spawnPosition.x = 0 - 2 + spawnPosition.x;
                stepPosition = new Vector3[numberOfSteps];
                nextStep = Instantiate(stepPrefab, spawnPosition, Quaternion.identity);
                stepPosition[x] = spawnPosition;
                x++;
                spawnPosition = stepPosition[x - 1];
            }
            else if (spawnPosition.x <= -3)
            {
                spawnPosition.x = 2 + spawnPosition.x;
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

    }
}