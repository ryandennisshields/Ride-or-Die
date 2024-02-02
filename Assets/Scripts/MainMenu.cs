using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string loadlevel = "Level"; // Stores the level

    // Function to start the game
    public void StartGame()
    {
        SceneManager.LoadScene(loadlevel); // Loads the first level

    } 

    // Function to quit the game
    public void QuitGame()
    {
        Application.Quit(); // Closes the game

    } 
}
