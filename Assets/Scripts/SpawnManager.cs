using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fishPrefab;
    void Start()
    {
        
        InvokeRepeating("SpawnFish", 3f, 3f);
    }

    private void SpawnFish(){
        Instantiate(fishPrefab, new Vector3(0,0,0), fishPrefab.transform.rotation);
    }
}
