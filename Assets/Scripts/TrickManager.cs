using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickManager : MonoBehaviour
{
    public static TrickManager instance; // Creates an instance of the script, allowing other code to use it

    public int scoreCount = 0; // Stores the score count

    public bool landed = true; // Stores a bool that decides if the player has landed or not

    public LongJump longJump; // Stores the long jump script
    public Flip flip; // Stores the flip script

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets the instance to this
    }

    // Start is called before the first frame update
    void Start()
    {
        LongJump.instance.enabled = true; // Start the long jump code
        Flip.instance.enabled = true; // Start the flip code
    }

    // Function for score counting 
    public void ScoreCount(int scoreToAdd)
    {
        scoreCount += scoreToAdd; // Adds on the score to the score count (the score count is created by tricks)
    }

    // Update is called once every frame
    void Update()
    { 
        if (PlayerController.instance.touchingGround == true)
        { // If the player is touching the ground,
            StartCoroutine(Landing()); // Start the landing coroutine
        }
    }

    // Coroutine for landing
    IEnumerator Landing()
    {
        if (landed == true)
        { // If landed is true,
            landed = false; // Set landed to false
            GameManager.instance.AddScore(scoreCount); // Add score to the total dependant on the calculated score count
            Boost.instance.Boosting(scoreCount); // Add boost to the player dependant on the calculated score count
            scoreCount = 0; // Set the score count back to 0
            UIManager.instance.tricksExecuted.text = "Good Landing\n\n"; // Creates the text "Good Landing" and displays it (overrites the text that shows the tricks executed)
            yield return new WaitForSeconds(1f); // Wait 1 seconds
            UIManager.instance.tricksExecuted.text = UIManager.instance.tricksExecuted.text.Replace("Good Landing\n\n", ""); // Removes the "Good Landing" text (by replacing it with nothing)
            yield return new WaitUntil(() => PlayerController.instance.touchingGround == false); // Wait until the player is no longer touching the ground
            landed = true; // Set landed to true
        }
    }
}
