using UnityEngine;

public class RopeController : MonoBehaviour
{
    public LineRenderer ropeRenderer;
    public Transform object1;
    public Transform object2;
    public Transform object3;

    void Start()
    {
        // Ensure you have the Line Renderer component attached in the Inspector
        ropeRenderer = GetComponent<LineRenderer>();

        // Set the positions of the Line Renderer based on the objects' positions
        ropeRenderer.positionCount = 3;
        ropeRenderer.SetPosition(0, object1.position);
        ropeRenderer.SetPosition(1, object2.position);
        ropeRenderer.SetPosition(2, object3.position);
    }
}
