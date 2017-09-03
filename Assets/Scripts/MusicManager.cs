using UnityEngine;
using System;

public class MusicManager : MonoBehaviour {
    public float decayRate = 0.01f;
    public float upRate = 0.1f;
    public float countdown = 1.0f;

    private float countdownTick;

    private AudioSource audioSource;
    private int musicalNotesOnMap = 0;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        countdownTick = countdown;

    }
	
	// Update is called once per frame
	void Update ()
    {
        countdownTick -= Time.deltaTime;
        if (audioSource.volume <= 0)
        {
            GameManager.GameOver();
        }
        else if (countdownTick <= 0.0f)
        {
            audioSource.volume -= decayRate;
            countdownTick = countdown;
        }
    }

    public void UpVolume()
    {
        audioSource.volume += upRate;
    }

    public void DownVolume()
    {
        audioSource.volume -= decayRate;
    }

    public Vector2 GenerateSpawnLocation()
    {
        float randX = UnityEngine.Random.Range(-15.0f, 15.0f);
        float randY = UnityEngine.Random.Range(-8.0f, 8.0f);
        return new Vector2(randX, randY);
    }

    public int GetMusicalNotesOnMap()
    {
        return musicalNotesOnMap;
    }

    public void SetMusicalNotesOnMap(int newVal)
    {
        musicalNotesOnMap = newVal;
    }

    internal String CurrentVolume()
    {
        return String.Format("{0:0.00}", audioSource.volume * 100);
    }
}
