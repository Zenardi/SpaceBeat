using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour {

    public float spawnCountdown = 5.0f;
    public Transform SpawnLocation;
    public GameObject alien;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown <= 0.0f)
        {
            SpawnAlien();
            spawnCountdown = 5.0f;
        }
    }

    private void SpawnAlien()
    {
        Instantiate(alien, SpawnLocation.position, SpawnLocation.rotation);
    }
}
