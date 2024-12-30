using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{

    //types of level names to load.
    public string levelToLoad;
    public LevelManager theLevelManager;
    private PlayerController thePlayer;

    public float waitToMove;
    public float waitToLoad;
    public Sprite flagOpen;
    private bool movePlayer;
    public SpriteRenderer theSpriteRenderer;
    // Use this for initialization
    void Start()
    {
        theLevelManager = FindAnyObjectByType<LevelManager>();
        thePlayer = FindAnyObjectByType<PlayerController>();
        
        theSpriteRenderer = FindAnyObjectByType<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movePlayer == true)
        {
            thePlayer.playerBody.linearVelocity = new Vector3(thePlayer.moveSpeed, thePlayer.playerBody.linearVelocity.y, 0f);
        }
    }

    //This trigger is used to load the new Level.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            theSpriteRenderer.sprite = flagOpen;
            StartCoroutine("LevelEndCo");
            // SceneManager.LoadScene (levelToLoad);
            // theTextBox.isActive = false;
        }
    }

    public IEnumerator LevelEndCo()
    {
        thePlayer.canMove = false;

        theLevelManager.invinsible = true;
        thePlayer.playerBody.linearVelocity = Vector3.zero;

        theLevelManager.levelMusic.Stop();
        theLevelManager.gameOverMusic.Play();

        PlayerPrefs.SetInt("PlayerLives", theLevelManager.CurrentLives);

        yield return new WaitForSeconds(waitToMove);

        movePlayer = true;

        yield return new WaitForSeconds(waitToLoad);

        SceneManager.LoadScene(levelToLoad);
    }

}