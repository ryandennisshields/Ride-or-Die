using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawn : MonoBehaviour
{
    public static TerrainSpawn instance; // Creates an instance of this script, allowing other code to use it
    
    public GameObject ground; // Stores the ground object

    public Transform spawnPoint; // Stores the position of the spawn point

    public int spawnLimit; // Stores the spawn limit

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets the instance to this
    }

    // Update is called every frame
    void Update()
    {
        if (spawnLimit <= 3)
        { // If the spawn limit is less than or equal to 3,
            Instantiate(ground, spawnPoint.position, spawnPoint.rotation); // Instatiate a chunk of terrain at the spawn point position and rotation
            spawnPoint.transform.position += new Vector3(ground.transform.position.x + 100, 0, 0); // Move the spawn point to the right dependant on the x value of the spawned ground
            spawnLimit++; // Increase the spawn limit by 1
        }
    }
}
