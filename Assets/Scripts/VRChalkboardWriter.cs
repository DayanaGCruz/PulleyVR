using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class VRChalkboardWriter : MonoBehaviour
{
    public XRController rightController;
    public LayerMask chalkboardLayer;
    public float writingSpeed = 0.02f;

    private bool isWriting;
    private GameObject currentChalkboard;
    private TextMesh textMesh;

    void Update()
    {
        HandleWritingInput();
    }

    void HandleWritingInput()
    {
        if (rightController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonState))
        {
            if (primaryButtonState)
            {
                if (!isWriting)
                {
                    // Start writing when the primary button is pressed
                    StartWriting();
                }
                else
                {
                    // Continue writing when the primary button is held
                    ContinueWriting();
                }
            }
            else if (isWriting)
            {
                // Stop writing when the primary button is released
                StopWriting();
            }
        }
    }

    void StartWriting()
    {
        RaycastHit hit;
        if (Physics.Raycast(rightController.transform.position, rightController.transform.forward, out hit, Mathf.Infinity, chalkboardLayer))
        {
            currentChalkboard = hit.collider.gameObject;
            textMesh = currentChalkboard.GetComponentInChildren<TextMesh>();
            isWriting = true;
        }
    }

    void ContinueWriting()
    {
        if (currentChalkboard != null && textMesh != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(rightController.transform.position, rightController.transform.forward, out hit, Mathf.Infinity, chalkboardLayer))
            {
                Vector3 localPoint = currentChalkboard.transform.InverseTransformPoint(hit.point);
                textMesh.text += "X"; // You can replace this with logic to draw lines or characters.
            }
        }
    }

    void StopWriting()
    {
        isWriting = false;
        currentChalkboard = null;
        textMesh = null;
    }
}
