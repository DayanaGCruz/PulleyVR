using System.Diagnostics;
using UnityEngine;

public class CubeConnection : MonoBehaviour
{
    public Transform block1;
    public Transform block2;
    public Transform wheel;
    public float velocity = 1.0f;
    private Rigidbody block1RGB;
    private Rigidbody block2RGB;
    //public float acceleration;
    public void Start()
    {
        //acceleration = (block1RGB.mass * 1f) / (block1RGB.mass + block2RGB.mass);
    }
    private void Update()
    {
        // Check if both cubes exist
        if (block1 != null && block2 != null)
        {
           if (block2.position.x <= wheel.position.x)
            {
                // Calculate the direction from wheel to cube2
                Vector3 direction = (wheel.position - block2.position).normalized;

                // Calculate the desired position for cube2
                Vector3 targetPosition = wheel.position + direction;

                // Move cube2 towards the target position using Lerp
                block2.position = Vector3.Lerp(block2.position, targetPosition, Time.deltaTime * velocity);
            }
            else
            {
                // Calculate the direction from cube2 to cube1
                Vector3 direction = (block1.position - block2.position).normalized;

                // Calculate the desired position for cube2
                Vector3 targetPosition = block1.position + direction;

                // Move cube2 towards the target position using Lerp
                block2.position = Vector3.Lerp(block2.position, targetPosition, Time.deltaTime * velocity);
            }
        }
    }
}