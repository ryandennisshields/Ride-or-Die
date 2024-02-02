using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public static EnemySpawning instance; // Stores the instance, allowing other code to use this code

    public GameObject zombie; // Stores the zombie object

    public Transform player; // Stores the position of the player
    public Transform spawnPoint; // Stores the position of the spawn point

    private bool spawning = true; // Stores a bool that decides if spawning is active or not

    private int spawnTime; // Stores the spawn time
    private int amountToSpawn; // Stores the amount to spawn (the amount of zombies that spawn)
    private float maxSpawnDelay = 5f; // Stores the maximum spawn delay 
    private float spawnDelay; // Stores the spawn delay

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets the instance to use this code
    }

    // Update is called once every frame
    void Update()
    {
        if (player.gameObject.activeSelf == true)
        { // If the player is active,
            transform.position = new Vector3(player.position.x + 75, 10, 0); // The spawn point follows the player depending on the player's X position
        }

        if (spawning == true)
        { // if spawning is true,
            StartCoroutine(SpawnSystem()); // Starts the coroutine spawn system
        }

        spawnDelay = maxSpawnDelay / PlayerController.instance.baseSpeed; // Sets the spawn delay by dividing the maximum spawn delay by the player's base speed (as the player's speed gets lower, the delay gets higher)
    }

    // Coroutine for spawn system
    IEnumerator SpawnSystem()
    {
        spawning = false; // Set spawning to false
        spawnTime = Random.Range(2, 4); // Sets the spawn time to a random number between 2 and 4
        amountToSpawn = Random.Range(4, 12); // Sets the amount to spawn to a random number between 4 and 12
        yield return new WaitForSeconds(spawnTime); // Waits for seconds equal to the spawn time
        for (int i = 0; i < amountToSpawn; i++)
        { // For the amount to spawn starting at 0 and adding on 1 every repeat,
            Instantiate(zombie, spawnPoint.position, spawnPoint.rotation); // Instatiate a zombie at the spawn point position and rotation
            yield return new WaitForSeconds(spawnDelay); // Wait for seconds equal to the spawn delay
        }
        spawning = true; // Set spawning to true
    }
}
