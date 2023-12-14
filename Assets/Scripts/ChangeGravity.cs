using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeGravity : MonoBehaviour
{
    public Slider gravitySlider;        // Reference to the Slider
    public TMP_Text gravityText;

    private void Start()
    {
        gravityText.text = Physics.gravity.y.ToString("F2"); // Display
        // Set the slider's min and max values based on your requirements.
        gravitySlider.minValue = -12;
        gravitySlider.maxValue = 12;
        gravitySlider.onValueChanged.AddListener(ChangeGravityValue);
    }

    public void ChangeGravityValue(float customGravityValue)
    {
        Vector3 customGravity = new Vector3(0f, -customGravityValue, 0f);
        Physics.gravity = customGravity;
        gravityText.text = Physics.gravity.y.ToString("F2"); // Display
        Debug.Log("Changed gravity");
    }
}
