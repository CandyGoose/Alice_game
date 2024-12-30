using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private LevelManager theLevelManager;

	// Use this for initialization
	void Start () {
        theLevelManager = FindAnyObjectByType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //16|4 Had problem with the GameOver screen, the buttons did not respond to the key presses.
    //19|4 problem solved In the project Hierarchy make sure the Game Over Screen is at the top so its not ovelapped
    //Being overlapped stops the buttons from working.


    public void Restart()
    {
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
