using UnityEngine;
using System.Collections;
using System;

public class FixToolManager : MonoBehaviour
{
    public GameObject fixToolPrefab;
    public float spawnCountdown = 5.0f;
    private float spawnCountdownTick;



    // Use this for initialization
    void Start()
    {
        spawnCountdownTick = spawnCountdown;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn Fix item
        spawnCountdownTick -= Time.deltaTime;
        
        if (spawnCountdownTick <= 0.0f)
        {
            spawnCountdownTick = spawnCountdown;
            SpawnFixTool();       
        }
        

    }

    private void SpawnFixTool()
    {
        try
        {
            GameObject.Instantiate(fixToolPrefab, GenerateSpawnLocation(), Quaternion.identity);
        }
        catch (Exception ex)
        {
            print("Null fix tool prefab " + ex.Message);
        }
    }

    public Vector2 GenerateSpawnLocation()
    {
        float randX = UnityEngine.Random.Range(-15.0f, 15.0f);
        float randY = UnityEngine.Random.Range(-8.0f, 8.0f);
        return new Vector2(randX, randY);
    }
}
