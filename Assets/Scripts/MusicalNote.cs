using UnityEngine;
using System.Collections;
using System;

public class MusicalNote : MonoBehaviour {
    private float spawnTimer;
    private MusicManager musicManager;
    public float destroyTimer = 3;
    private AudioSource audioSource;
    // Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            musicManager.SetMusicalNotesOnMap(musicManager.GetMusicalNotesOnMap() - 1);
            Destroy(gameObject);
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (musicManager == null) { print("music manager null"); return; }
       
        if(other.gameObject.tag.Equals("Player"))
        {
            musicManager.SetMusicalNotesOnMap(musicManager.GetMusicalNotesOnMap() - 1);
            musicManager.UpVolume();
            PlayPickSound();
            Destroy(gameObject);
        }

    }

    private void PlayPickSound()
    {
        if(audioSource==null) { print("MusicalNote: AudioSource NULL"); return; }
        audioSource.Play();
    }
}
