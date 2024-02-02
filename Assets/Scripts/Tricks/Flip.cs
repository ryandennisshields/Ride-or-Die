using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public static Flip instance; // Stores the instance, allowing other scripts to use this code
    
    private bool trick = true; // Stores a bool that decides if the trick is true or not

    private float amountToRotate; // Stores the amount to rotate
    private float rotatorAngle; // Stores the rotator angle

    // Awake is called when the script loads
    void Awake()
    {
        instance = this; // Sets the instance to this
    }

    // Update is called once every frame
    void Update()
    {
        StartCoroutine(FlipCheck()); // Start the flip check coroutine

        if (PlayerController.instance.touchingGround == true)
        { // If the player is touching the ground,
            amountToRotate = PlayerController.instance.transform.rotation.z + (PlayerController.instance.transform.rotation.z < 0 ? 0.01f : -0.01f); // Set the amount to rotate to the player's rotation, plus 0.01 if the rotation is less than 0, or take away 0.01 if the rotation is greater than 0
        }
    }

    // Coroutine for flip checking
    IEnumerator FlipCheck()
    {
        if (trick == true)
        { // If the trick is true,
            if (PlayerController.instance.touchingGround == false)
            { // If the player is not touching the ground,
                if (PlayerController.instance.transform.rotation.z < amountToRotate)
                { // If the player's rotation is less than the amount to rotate (the player rotates enough to do a flip),
                    trick = false; // Set trick to false
                    rotatorAngle = PlayerController.instance.transform.rotation.z + (PlayerController.instance.transform.rotation.z < 0 ? 0.01f : -0.01f); // Set the rotator angle to the player's rotation, plus 0.01 if the rotation is less than 0, or take away 0.01 if the rotation is greater than 0
                    yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
                    if (rotatorAngle < PlayerController.instance.transform.rotation.z)
                    { // If the rotator angle is less than the player's rotation,
                        TrickManager.instance.ScoreCount(200); // Add 200 to the score count 
                        UIManager.instance.tricksExecuted.text += "Backflip + "; // Add the text "Backflip + " to the tricks executed
                    }
                    if (rotatorAngle > PlayerController.instance.transform.rotation.z)
                    { // If the rotator angle is greater than the player's rotation,
                        TrickManager.instance.ScoreCount(200); // Add 200 to the score count
                        UIManager.instance.tricksExecuted.text += "Frontflip + "; // Add the text "Frontflip + " to the tricks executed
                    }
                    yield return new WaitUntil(() => PlayerController.instance.transform.rotation.z > amountToRotate); // Wait until the player's rotation is greater than the amount to rotate (makes sure the player does a full flip before counting)
                    trick = true; // Set trick to true
                }
            }
        }
    }
}
