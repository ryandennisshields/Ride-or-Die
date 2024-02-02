using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneX : MonoBehaviour
{
    public Transform player; // Stores the player's position

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.activeSelf == true)
        { // If the player is active,
            transform.position = new Vector3(player.position.x - 200, 0, 0); // The kill plane follows the player depending on the player's X position 
        }
    }

    // On trigger enter is called whenever this object hits a trigger
    void OnTriggerEnter2D(Collider2D other)
    { 
        Destroy(other.gameObject); // Destroy the other object
    }
}
