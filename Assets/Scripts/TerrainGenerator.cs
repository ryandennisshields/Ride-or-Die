using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainGenerator : MonoBehaviour
{
    public SpriteShapeController terrain; // Stores the sprite shape controller terrain

    private int scale = 100; // Stores the scale (the maximum width of the terrain)
    private int numofPoints = 20; // Stores the number of points (the number of points generated on the terrain)
    private int distanceBwtnPoints; // Stores the distance between points
    private int pointHeight = 10; // Stores the point height
    private float pointMin = 20f; // Stores the point minimum (the lowest a point can be)
    private float pointMax = 40f; // Stores the point minimum (the highest a point can be)
    private int pointSmoothness = 2; // Stores the point smoothness (how curved each point is)
    
    // Start is called before the first frame update
    void Start()
    {
        distanceBwtnPoints = scale / numofPoints; // Sets the distance between points dependant on the scale divided by the number of points
        terrain.spline.SetPosition(2, terrain.spline.GetPosition(2) + Vector3.right * scale); // Sets the 2nd point of the terrain (top-right) far along to the right dependant on the scale
        terrain.spline.SetPosition(3, terrain.spline.GetPosition(3) + Vector3.right * scale); // Sets the 3rd point of the terrain (bottom-right) far along to the right dependant on the scale

        for (int i = 0; i < numofPoints; i++)
        { // For the number of points starting at 0 adding on 1,
            float xPos = terrain.spline.GetPosition(i + 1).x + distanceBwtnPoints; // Sets a X position float to the x position of the point dependant on the i value plus 1 (to make it start from the top-left point) plus the distance between points
            terrain.spline.InsertPointAt(i + 2, new Vector3(xPos, pointHeight * Mathf.PerlinNoise(i * Random.Range(pointMin, pointMax), 0))); // Adds a point dependant on the i value plus 2 (to make it start from the top-right point) to the calculated x value and the y value, which is calculated by the point height, multipled by a perlin noise (randomly-generated 2D waves) dependant on the i value, times a random range from the point minimum and maximum
        }

        for (int i = 2; i < numofPoints + 2; i++)
        { // For the number of points plus 2 starting at 2 (the top-right point) adding on 1,
            terrain.spline.SetTangentMode(i, ShapeTangentMode.Continuous); // Set the point tangenet mode to continous (makes the generated points smoother)
            terrain.spline.SetLeftTangent(i, new Vector3(-pointSmoothness, 0, 0)); // Set the left tangent dependant on the negative of the point smoothness (smooths down the left side)
            terrain.spline.SetRightTangent(i, new Vector3(pointSmoothness, 0, 0)); // Set the right tangent dependant on the point smoothness (smooths down the right side)
        }
    }

    // Called when this object is destroyed
    private void OnDestroy()
    { 
        TerrainSpawn.instance.spawnLimit--; // Decreases the terrain spawn limit (allows another chunk of terrain to spawn)
    }
}
