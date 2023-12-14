using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class XRDropdownSelector : MonoBehaviour
{
    private XRRayInteractor rayInteractor;

    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();

        // Subscribe to raycastHit event
        rayInteractor.onSelectEntered.AddListener(OnRaycastHit);
    }

    void OnRaycastHit(XRBaseInteractable interactable)
    {
        // Check if the interactable is a UI element
        if (interactable is XRBaseInteractable)
        {
            // Get the UI object
            GameObject uiObject = interactable.gameObject;

            // Check if it's a Dropdown
            Dropdown dropdown = uiObject.GetComponent<Dropdown>();
            if (dropdown != null)
            {
                // Open or close the dropdown
                dropdown.Show();
            }

            // Check if it's a Text component (dropdown item)
            Text dropdownTextItem = uiObject.GetComponent<Text>();
            if (dropdownTextItem != null)
            {
                // Simulate a click on the dropdown item
                ExecuteEvents.Execute(uiObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            }
        }
    }
}
