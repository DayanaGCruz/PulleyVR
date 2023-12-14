using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Check for user input to toggle pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        // If the game is paused, set timeScale to 0 (freezing time)
        // If the game is resumed, set timeScale back to 1 (normal time flow)
        Time.timeScale = isPaused ? 0f : 1f;

        // Optionally, you can also toggle other pause-related functionalities, like showing/hiding UI elements, etc.
    }
}

