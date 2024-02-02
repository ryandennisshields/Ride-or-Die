using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // On collision enter is called when another object collides with this one
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        { // If the other object has the tag "Player",
            if (PlayerController.instance.baseSpeed > 20)
            { // If the player's base speed is greater than 20,
                GameManager.instance.AddScore(200); // Adds 200 score using the game manager 
                Destroy(this.gameObject); // Destroy this object
            }
            else
            { // If the player's base speed is not greater than 20,
                PlayerController.instance.baseSpeed -= 5f; // Decrease the player's base speed by 5
                Destroy(this.gameObject); // Destroy this object
            }
        }     
    }
}
