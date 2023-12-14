using UnityEngine;

public class PulleyController : MonoBehaviour
{
    public Transform cube1;     // Reference to the first cube
    public Transform cube2;     // Reference to the second cube
    public Transform pulley;    // Reference to the pulley GameObject
    public float ropeLength = 5.0f; // Length of the rope

    private HingeJoint hinge1;
    private HingeJoint hinge2;
    private float initialDistance;

    private void Start()
    {
        // Get the HingeJoint components from the cubes
        hinge1 = cube1.GetComponent<HingeJoint>();
        hinge2 = cube2.GetComponent<HingeJoint>();

        // Store the initial distance between the cubes
        initialDistance = Vector3.Distance(cube1.position, cube2.position);
    }

    private void Update()
    {
        // Calculate the current distance between the cubes
        float currentDistance = Vector3.Distance(cube1.position, cube2.position);

        // Calculate the difference in distance
        float distanceDifference = initialDistance - currentDistance;

        // Calculate the rope length change factor
        float ropeChangeFactor = distanceDifference / ropeLength;

        // Calculate the target angles for the hinge joints
        float angle1 = Mathf.Asin(ropeChangeFactor) * Mathf.Rad2Deg;
        float angle2 = -angle1;

        // Update the target angles of the hinge joints
        JointSpring spring1 = hinge1.spring;
        spring1.targetPosition = angle1;
        hinge1.spring = spring1;

        JointSpring spring2 = hinge2.spring;
        spring2.targetPosition = angle2;
        hinge2.spring = spring2;
    }
}
