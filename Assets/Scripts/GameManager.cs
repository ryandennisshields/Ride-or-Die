using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Stores the instance, allowing other players to use this code
    
    public float currentScore = 0; // Stores the current score
    
    private bool increaseDifficulty = true; // Stores a bool that decides whether the difficulty increases or not

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets the instance to use this code
    }

    // Start is called before the first frame update
    void Start()
    {      
        StartCoroutine(DifficultyOverTime()); // Starts the coroutine for difficulty over time

        Time.timeScale = 1; // Sets the time scale to 1 (makes the game run at normal speed)
    }

    // The function for adding score
    public void AddScore(float scoreToAdd)
    {
        currentScore += scoreToAdd; // Adds on the score to the current score
        UIManager.instance.scoreText.text = "" + currentScore; // Displays the current score after being updated
    }

    // Called when the player dies
    public void KillPlayer()
    {
        GameObject Player = GameObject.Find("Player"); // Finds a game object with the name "Player"
        Player.SetActive(false); // Sets the player to false (so the player can't do anything)
        GameObject EnemySpawning = GameObject.Find("Zombie Spawning"); // Finds a game object with the name "Zombie Spawning"
        EnemySpawning.SetActive(false); // Sets the enemy spawning to false (so no other enemies spawn)
        GameObject TerrainSpawning = GameObject.Find("Terrain Spawning"); // Finds a game object with the name "Terrain Spawning"
        TerrainSpawning.SetActive(false); // Sets the terrain spawing to false (so no more terrain spawns)
        UIManager.instance.gameOverscreen.SetActive(true); // Displays the game over screen
        UIManager.instance.tricksExecuted.gameObject.SetActive(false); // Sets the trick display off 
        UIManager.instance.scoreText.gameObject.SetActive(false); // Sets the score text off 
        UIManager.instance.boostMeter.gameObject.SetActive(false); // Sets the boost meter element off
        UIManager.instance.backwardButton.gameObject.SetActive(false); // Set the backward button element off
        UIManager.instance.forwardButton.gameObject.SetActive(false); // Set the forward button element off
        HighScore.instance.CalculateLeaderboard(); // Calls the calculate leaderboard function
        Time.timeScale = 0; // Sets the time scale to 0 (freezes the game)
    }

    // Coroutine for the difficulty over time
    IEnumerator DifficultyOverTime()
    {
        while (increaseDifficulty == true)
        { // While increase difficulty is true,
            increaseDifficulty = false; // Set increase difficulty to false
            yield return new WaitForSeconds(30f); // Wait for 30 seconds
            PlayerController.instance.speedMultipler += 0.2f; // Increase the speed multiplier for the player (makes the player's overall speed faster)
            increaseDifficulty = true; // Set increase difficulty to true
        }
    }
}
