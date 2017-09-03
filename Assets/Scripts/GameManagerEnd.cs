using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadSpaceLevel()
    {
        SceneManager.LoadScene("Space");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void ExitSpaceBeat()
    {
        Application.Quit();
    }
}
