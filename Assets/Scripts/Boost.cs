using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public static Boost instance; // Stores the instance, allowing other code to use this code

    private bool activateBoost = true; // Stores a bool that decides whether boosting is active or not
    private bool speedReset = true; // Stores a bool that decides whether the player's speed gets reset or not

    public float boostValue; // Stores the boost value

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets the instance to use this code
    }

    // Update is called once every frame
    void Update()
    {
        StartCoroutine(boostEffect()); // Starts the coroutine boost effect
        StartCoroutine(resetSpeed()); // Starts the coroutine reset speed
    }

    // Function for boosting
    public void Boosting(float boostAmount)
    {
        boostValue += boostAmount / 25; // Sets the boost value to the value of the boost amount divided by 25
        if (boostValue > 100)
        { // If the boost value is greater than 100,
            boostValue = 100; // Set the boost value to 100 (caps the boost value to never go above 100)
        }
    }

    // Coroutine for boost effect
    IEnumerator boostEffect()
    {
        if (boostValue > 0)
        { // If boost value is greater than 0,
            UIManager.instance.boostMeter.gameObject.SetActive(true); // Set the boost meter from the UI to true (makes a boost meter appear on screen)
            if (activateBoost == true)
            { // If activate boost is true,
                activateBoost = false; // Set activate boost to false
                PlayerController.instance.baseSpeed = 30; // Set the player's base speed to 30 (makes the player faster)
                yield return new WaitForSeconds(0.1f); // Wait 0.1 seconds
                boostValue -= 1; // Decrease the boost value by 1
                activateBoost = true; // Set activate boost to true
            }
        }
    }

    // Coroutine for reset speed
    IEnumerator resetSpeed()
    {
        if (boostValue == Mathf.RoundToInt(boostValue * 0.01f))
        { // If the boost value is equal to the current boost value times 0.01, then rounded to the nearest integer,
            if (speedReset == true)
            { // If speed reset is true,
                speedReset = false; // Set reset speed to false
                PlayerController.instance.baseSpeed = 20; // Set the player's base speed to 20 (resets the player's speed)
                UIManager.instance.boostMeter.gameObject.SetActive(false); // Set the boost meter from the UI to false (makes the boost meter disappear from the screen)
                yield return new WaitUntil(() => PlayerController.instance.baseSpeed == 30); // Wait until the player's base speed reaches 30 (the boost speed) 
                speedReset = true; // Set the reset speed to true
            }
        }
    }
}
