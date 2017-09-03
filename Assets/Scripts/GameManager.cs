using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    public int maxMusicNotes = 4;
    public Text hp;
    public Text musicVol;
    public Text timeLapsed;
    public GameObject spawnNotePrefab;
    public float timeToSpawnMusicalNote = 2.5f;

    private float elapsedTime = 0;
    private MusicManager musicManager;
    private SpPlayerController player;
    private float timeToSpawnMusicalNoteTick;
   

    // Use this for initialization
    void Start () {
	    musicManager = GameObject.FindObjectOfType<MusicManager>();
        player = GameObject.FindObjectOfType<SpPlayerController>();
        //spawnNotePrefab = GameObject.FindGameObjectWithTag("MusicalNote");
        elapsedTime = 0;
        timeToSpawnMusicalNoteTick = timeToSpawnMusicalNote;
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateUI();
        elapsedTime += Time.deltaTime;
        timeToSpawnMusicalNoteTick -= Time.deltaTime;
        if (timeToSpawnMusicalNoteTick <= 0.0f || musicManager.GetMusicalNotesOnMap() < maxMusicNotes)
        {
            SpawnMusicalNote();
            timeToSpawnMusicalNoteTick = timeToSpawnMusicalNote;
        }
    }

    private void SpawnMusicalNote()
    {
        try
        {
            GameObject.Instantiate(spawnNotePrefab, musicManager.GenerateSpawnLocation(), Quaternion.identity);
            musicManager.SetMusicalNotesOnMap(musicManager.GetMusicalNotesOnMap() + 1);
        }
        catch(Exception ex)
        {
            print("Null Spawn Note " + ex.Message);
        }

    }

    internal static void GameOver()
    {
        // Call game over screen
        SceneManager.LoadScene("GameOver");
    }

    public static void LoadSpaceLevel()
    {
        SceneManager.LoadScene("Space");
    }

    public static void ExitSpaceBeat()
    {
        Application.Quit();
    }

    private void UpdateUI()
    {
        musicVol.text = "Music: " + musicManager.CurrentVolume() + "%";
        hp.text = "HP: " + player.getHP();
        decimal decimalValue = Math.Round((decimal)elapsedTime, 3);

        // TODO reset time counter when retry playing
        timeLapsed.text = "Time: " + decimalValue.ToString();
    }
}
