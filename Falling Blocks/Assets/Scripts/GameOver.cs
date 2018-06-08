using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen; // Reference to the Game Over screen object
    public Text secondsSurviviedUI; // Reference to the Seconds Survived UI text element
    bool gameOver; // Bool variable for cheking if the game is over

    void Start() {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver; // Subscribing the OnGameOver method to the OnPlayerDeath event from the PlayerController script
    }

    // Update is called once per frame
    void Update () {
        if (gameOver) { // If game is over
            if (Input.GetKeyDown(KeyCode.Space)) { // And space is pressed
                SceneManager.LoadScene(0); // Reload the scene
            }
        }
	}

    void OnGameOver() {
        gameOverScreen.SetActive(true); // Set game over screen object to Active
        secondsSurviviedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString(); // Count of the seconds survived from the begining of the round
        gameOver = true; // gameOver is true, when the game is over (no shit sherlock!)
    }
}
