using System.Diagnostics;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public Transform mass1;          // Reference to the first mass.
    public Transform mass2;          // Reference to the second mass.
    public Transform pulley; // Reference to the pulley wheel.
    public float ropeWidth = 0.05f;  // Width of the rope line.

    private LineRenderer lineRenderer;

    private void Start()
    {
        // Get the LineRenderer component attached to this GameObject.
        lineRenderer = GetComponent<LineRenderer>();

        // Set the width of the line.
        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;
    }

    private void Update()
    {
        if (mass1 != null && mass2 != null && pulley != null)
        {
            // Set the attachment points to the sides of the wheel
            Vector3 sidePoint1 = pulley.position + pulley.right * (pulley.localScale.z * 0.5f);
            Vector3 sidePoint2 = pulley.position - pulley.right * (pulley.localScale.z * 0.5f);

            // Set the positions of the LineRenderer to connect the two masses and the pulley cylinder.
            lineRenderer.SetPosition(0, mass1.position);
            lineRenderer.SetPosition(1, sidePoint1);
            lineRenderer.SetPosition(2, sidePoint2);
            lineRenderer.SetPosition(3, mass2.position);
        }
    }
}
