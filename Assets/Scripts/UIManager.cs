using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; // Allows other scripts to use UImanager's code

    public GameObject gameOverscreen; // Stores the game over screen
    
    public TMP_Text scoreText; // Stores the score text
    public TMP_Text endScoreText; // Stores the ending score text
    public TMP_Text tricksExecuted; // Stores the tricks executed text

    public Slider boostMeter; // Stores the boost meter slider

    public Image backwardButton; // Stores the backward button
    public Image forwardButton; // Stores the forward button

    public float score; // Stores the score

    public string mainMenuName = "Main Menu"; // Stores the main menu name, and names it Main Menu

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Creates an instance of this script, allowing other scripts to use UImanager's code

    }

    // Update is called once every frame
    void Update()
    {
        score = GameManager.instance.currentScore; // Sets the score text to the current score
        endScoreText.text = "" + score; // Updates the end score text to show the score (shows when the player game overs)

        boostMeter.value = Boost.instance.boostValue; // Sets the value of the boost meter slider to the boost value
    }

    // The function to restart
    public void Restart()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restarts the current scene
    }

    // The function to quit to main menu
    public void QuitToMainMenu()
    {
    SceneManager.LoadScene(mainMenuName); // Loads the main menu screen
    }
}
