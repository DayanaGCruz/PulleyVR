using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class MoveVR : MonoBehaviour
{
    public XRController leftController;
    public XRController rightController;
    public float speed = 3.0f;

    void Update()
    {
        HandleMovementInput(leftController);
        HandleMovementInput(rightController);
    }

    void HandleMovementInput(XRController controller)
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 thumbstickValue))
        {
            Vector3 moveDirection = new Vector3(thumbstickValue.x, 0, thumbstickValue.y).normalized;

            // Apply movement to the player
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }
}
