
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MassChanger : MonoBehaviour
{
    public GameObject targetObject;  // Drag the target object you want to change the mass of into this field in the Inspector
    public Slider massSlider;        // Reference to the Slider
    public TMP_Text massText;
    private Rigidbody targetRigidbody;
    public float startMass;

    private void Start()
    {
        targetRigidbody = targetObject.GetComponent<Rigidbody>();
        massText.text = targetRigidbody.mass.ToString("F2");
        // Set the slider's min and max values based on your requirements.
        // For example, to change mass from 1 to 10, set the min value to 1 and the max value to 10.
        massSlider.minValue = 1;
        massSlider.maxValue = 200;
        massSlider.onValueChanged.AddListener(ChangeMass);
        massSlider.value = startMass;
    }

    // This method is called when the Slider value changes
    public void ChangeMass(float newMass)
    {
        if (targetRigidbody != null)
        {
            targetRigidbody.mass = newMass;
            massText.text = targetRigidbody.mass.ToString("F2");

        }
        else
        {
            Debug.Log("mass rigid body is null");
        }
    }
}
