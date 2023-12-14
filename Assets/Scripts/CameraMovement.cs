using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this to control the movement speed.

    void Update()
    {
        // Get input from arrow keys or WASD keys.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction.
        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Normalize the direction vector to ensure consistent speed regardless of diagonal movement.
        movementDirection.Normalize();

        // Translate the camera's position based on input and speed.
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }
}
