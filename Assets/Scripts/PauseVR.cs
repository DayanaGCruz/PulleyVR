using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseGameXR : MonoBehaviour
{
    private bool isPaused = false;
    private XRController oculusController;

    void Start()
    {
        // Find the XR controller for the Oculus device
        oculusController = GetComponent<XRController>();

        if (oculusController == null)
        {
            Debug.LogError("XRController not found on the GameObject.");
        }
    }

    void Update()
    {
        // Check for Oculus controller input to toggle pause
        if (oculusController.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButtonState) && gripButtonState)
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
    }
}