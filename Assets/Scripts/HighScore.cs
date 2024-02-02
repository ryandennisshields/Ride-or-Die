using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    public static HighScore instance; // Stores the instance, allowing other scripts to use this code
    
    public TMP_Text firstScore; // Stores the first place score
    public TMP_Text secondScore; // Stores the second place score
    public TMP_Text thirdScore; // Stores the third place score
    public TMP_Text fourthScore; // Stores the fourth place score
    public TMP_Text fifthScore; // Stores the fifth place score

    private float score; // Stores the score

    // Awake is called when the script is loaded
    void Awake()
    {
        instance = this; // Sets the instance to use this code
    }

    // Function for calculating the leaderboard
    public void CalculateLeaderboard()
    {
        score = UIManager.instance.score; // Gets the score from the End of Level total score
        firstScore.text = PlayerPrefs.GetFloat("FirstScore", 000000).ToString(); // Sets the first score to the first score stored within the player's registry
        secondScore.text = PlayerPrefs.GetFloat("SecondScore", 000000).ToString(); // Sets the second score to the second score stored within the player's registry
        thirdScore.text = PlayerPrefs.GetFloat("ThirdScore", 000000).ToString(); // Sets the third score to the third score stored within the player's registry
        fourthScore.text = PlayerPrefs.GetFloat("FourthScore", 000000).ToString(); // Sets the fourth score to the fourth score stored within the player's registry
        fifthScore.text = PlayerPrefs.GetFloat("FifthScore", 000000).ToString(); // Sets the fifth score to the fifth score stored within the player's registry

        if (score > PlayerPrefs.GetFloat("FifthScore", 000000) && score < PlayerPrefs.GetFloat("FourthScore", 000000))
        { // If the player's earned score is greater than the stored fifth score and less than the stored fourth score,
            PlayerPrefs.SetFloat("FifthScore", score); // Set the fifth score to the player's earned score
            fifthScore.text = score.ToString(); // Display the new score on the leaderboard
        }
        if (score > PlayerPrefs.GetFloat("FourthScore", 000000) && score < PlayerPrefs.GetFloat("ThirdScore", 000000))
        { // If the player's earned score is greater than the stored fourth score and less than the stored third score,
            PlayerPrefs.SetFloat("FourthScore", score); // Set the second score to the player's earned score
            fourthScore.text = score.ToString(); // Display the new score on the leaderboard
        }
        if (score > PlayerPrefs.GetFloat("ThirdScore", 000000) && score < PlayerPrefs.GetFloat("SecondScore", 000000))
        { // If the player's earned score is greater than the stored third score and less than the stored second score,
            PlayerPrefs.SetFloat("ThirdScore", score); // Set the third score to the player's earned score
            thirdScore.text = score.ToString(); // Display the new score on the leaderboard
        }
        if (score > PlayerPrefs.GetFloat("SecondScore", 000000) && score < PlayerPrefs.GetFloat("FirstScore", 000000))
        { // If the player's earned score is greater than the stored second score and less than the stored first score,
            PlayerPrefs.SetFloat("SecondScore", score); // Set the second score to the player's earned score
            secondScore.text = score.ToString(); // Display the new score on the leaderboard
        }
        if (score > PlayerPrefs.GetFloat("FirstScore", 000000))
        { // If the player's earned score is greater than the stored first score,
            PlayerPrefs.SetFloat("FirstScore", score); // Set the first score to the player's earned score
            firstScore.text = score.ToString(); // Display the new score on the leaderboard
        }
    }
}
