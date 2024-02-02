using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // Stores the instance, allowing other scripts to use this code
    
    public Rigidbody2D player; // Stores the rigidbody

    public float baseSpeed; // Controls the speed the car moves forward
    public float speedMultipler;  // Stores the speed multiplier
    private float rotationSpeed = 2f; // Controls the speed of rotation 
    private float rotationDirection = 0f; // Stores the rotation direction 

    public Transform groundCheck; // Stores the ground check location (located at the player's bottom)
    private Vector2 groundCheckSize = new Vector2(2f, 1f); // Stores the ground check size (The size of the ground check across the x and y axis)
    public bool touchingGround; // Stores the touching ground boolean (If the player is touching the ground or not)

    public Transform flippedCheck; // Stores the flipped check location (located at the player's top)
    private Vector2 flippedCheckSize = new Vector2(1f, 1f); // Stores the flipped check size (The size of the flip check across the x and y axis)
    public bool flipped; // Stores the flipped boolean (If the player is flipped or not)

    public LayerMask groundLayer; // Stores the layer mask of the ground (The layer assigned to the ground)

    private bool speedUp = true; // Stores a bool that decides whether the player speeds up or not

    // Awake is called when this script is loaded
    void Awake()
    {
        instance = this; // Sets the instance to this
    }

    // Update is called every frame
    void Update()
    {
        touchingGround = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer); // Sets touching ground check to be true whenever a box overlaps with the ground layer
        flipped = Physics2D.OverlapBox(flippedCheck.position, flippedCheckSize, 0, groundLayer); // Sets the flipped check to be true whenever a box overlaps with the ground layer

        if (Input.touchCount > 0)
        { // If the touch count is greater than 0,
            var touch = Input.GetTouch(0); // Creates a touch variable that detects a touch input
            if (touch.position.x < Screen.width / 2)
            { // If the touch position is less than half the screen's width,
                rotationDirection = -1; // Set the rotation direction to -1 (rotates backwards)
            }
            else if (touch.position.x > Screen.width / 2)
            { // If the touch position is greater than half the screen's width,
                rotationDirection = 1; // Set the rotation direction to 1 (rotates forwards)
            }
        }
        else
        { // If the touch count is not greater than 0,
            rotationDirection = 0; // Set the rotation direction to 0
        }

        transform.position += new Vector3(baseSpeed * speedMultipler * Time.deltaTime, 0, 0); // Moves the car forward by mutliplying the base speed with the speed multiplier

        if (flipped == true)
        { // If flipped is true,
            GameManager.instance.KillPlayer(); // Kills the player
        }
        
        if (baseSpeed <= 5)
        { // If the player's base speed is less than or equal to 5,
            GameManager.instance.KillPlayer(); // Kills the player
        }
    }

    // Fixed update is called once every physics engine frame
    void FixedUpdate()
    {
        if (rotationDirection < 0f || rotationDirection > 0f)
        { // If the rotation direction is less than 0 or greater than 0,
            transform.Rotate(new Vector3(0, 0, -rotationDirection * rotationSpeed)); // Rotate the player dependant on the rotation direction times the rotate speed
            rotationSpeed *= 1.05f; // Increase the rotation speed times 1.05
            if (rotationSpeed >= 6f)
            { // If rotation speed is greater than or equal to 
                rotationSpeed = 6f; // Set the rotation speed to 6 (caps the rotation speed)
            }
        }
        else
        { // If the rotation direction is not less than 0 or greater than 0,
            rotationSpeed = 2f; // Set the rotation speed to 2
            rotationDirection = 0f; // Set the rotation direction to 0
        }

        if (baseSpeed < 20 && speedUp == true)
        { // If the base speed is less than 20 and speed up is true,
            StartCoroutine(SpeedUpAfterSlow()); // Start the speed up after slow coroutine
        }
        else
        { // If the base speed is not less than 20 and speed up is not true,
            StopCoroutine(SpeedUpAfterSlow()); // Stop the speed up after slow coroutine
        }
    }

    // Coroutine for speed up after slow
    IEnumerator SpeedUpAfterSlow()
    {
        speedUp = false; // Set speed up to false
        yield return new WaitForSeconds(2f); // Wait 2 seconds
        if (baseSpeed < 20f)
        { // If base speed is less than 20,
            baseSpeed += 1f; // Increase the base speed by 1
        }
        speedUp = true; // Set speed up to true
    }
}
