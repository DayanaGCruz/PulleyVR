using UnityEngine;
using TMPro;

public class WelcomeText : MonoBehaviour
{
    public TMP_Text splashText;
    public float displayTime = 35f; // Total time in seconds
    private float timer;

    void Start()
    {
        // Initialize the timer
        timer = 0f;

        // Ensure the text is not visible initially
        splashText.enabled = false;
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check the time range and set the text accordingly
        if (timer < 5f)
        {
            splashText.text = "Welcome to PulleyVR!";
        }
        else if (timer < 15f)
        {
            splashText.text = "The purpose of this lab is to practice your basic Physics knowledge through pulley systems!";
        }
        else if (timer < 30f)
        {
            splashText.text = "Your objective is to solve the given challenges by changing the state of the systems.";
        }
        else if (timer < 35f)
        {
            splashText.text = "Let's begin!";
        }
        // Check if the timer exceeds the display time
        if (timer < displayTime)
        {
            // Display the splash text
            splashText.enabled = true;
        }
        else
        {
            // Hide the splash text after the display time
            splashText.enabled = false;
        }
    }
}