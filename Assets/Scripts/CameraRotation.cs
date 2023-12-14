using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 2.0f; // Adjust this to control the rotation speed.

    private Vector3 lastMousePosition;

    void Update()
    {
        // Check for mouse input to rotate the camera.
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // Calculate the mouse movement delta.
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

            // Calculate rotation angles based on mouse movement.
            float rotationX = mouseDelta.y * rotationSpeed;
            float rotationY = -mouseDelta.x * rotationSpeed;

            // Apply the rotations to the camera's transform.
            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.left, rotationX, Space.Self);

            // Store the current mouse position for the next frame.
            lastMousePosition = Input.mousePosition;
        }
    }
}
