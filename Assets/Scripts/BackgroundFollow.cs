using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform cam; // Stores the position of the camera

    // Update is called once every frame
    void Update()
    {
        transform.position = new Vector3(cam.position.x, 35, 10); // The background follows the camera depending on the camera's X position
    }
}
