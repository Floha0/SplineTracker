using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fishPrefab;
    private float startTime = 1.5f;
    private float delayTime = 1.6f;

    void Start()
    {
        InvokeRepeating("SpawnFish", startTime, delayTime);
    }

    private void SpawnFish()
    {
        int fishIndex = Random.Range(0, fishPrefab.Length);
        Instantiate(
            fishPrefab[fishIndex],
            new Vector3(0, 0, 0),
            fishPrefab[fishIndex].transform.rotation
        );
    }
}
