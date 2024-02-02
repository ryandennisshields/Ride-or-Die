using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJump : MonoBehaviour
{
    public static LongJump instance; // Stores the instance, allowing other scripts to use this code
    
    private bool trick = true; // Stores a bool that decides if the trick is true or not

    // Awake is called when the script loads
    void Awake()
    {
        instance = this; // Sets the instance to this
    }

    // Update is called once every frame
    void Update()
    {
        StartCoroutine(LongJumpCheck()); // Starts the long jump check coroutine
    }

    // Coroutine for long jump checking
    IEnumerator LongJumpCheck()
    {
        if (trick == true)
        { // If trick is true,
            if (PlayerController.instance.touchingGround == false)
            { // If the player is touching the ground,
                trick = false; // Set trick to false
                yield return new WaitForSeconds(5f); // Wait 5 seconds
                trick = true; // Set trick to true
                if (PlayerController.instance.touchingGround == false)
                { // If the player is not touching the ground,
                    TrickManager.instance.ScoreCount(100); // Add 100 to the score count
                    UIManager.instance.tricksExecuted.text += "Long Jump + "; // Add the text "Long Jump + " to the tricks executed
                }
            }
        }
    }
}
