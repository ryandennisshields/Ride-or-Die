using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Stores the position of the player

    public Camera cam; // Stores the camera

    // Update is called once every frame
    void Update()
    {
        if (player.gameObject.activeSelf == true)
        { // If the player is active,
            transform.position = new Vector3(player.position.x + 10, player.position.y, -10); // Camera follows the player depending on the player's X position and Y position (-10 on the Z axis keeps the camera at the back) 
            cam.orthographicSize = player.position.y + 10; // Scales the camera's size to the y position to the player so it zooms outwards

        }
    }
} 
