using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PulleyRadiusChanger : MonoBehaviour
{
    public GameObject targetObject;   
    public Slider scaleSlider;      // Reference to the Scale Slider  
    public TMP_Text scaleText;

    private void Start()
    {
        // Assuming that the target object has a Transform component
        if (targetObject != null)
        {
            scaleSlider.minValue = 0.1f; // Set the min value 
            scaleSlider.maxValue = 1.0f; // Set the max value 
            scaleSlider.onValueChanged.AddListener(ChangeScale);
            scaleSlider.value = targetObject.transform.localScale.x;


            UpdateScaleText();
        }
        else
        {
            Debug.LogError("Target object is null or missing a Transform component.");
        }
    }

    // This method is called when the  Scale Slider value changes
    public void ChangeScale(float newScaleXY)
    {
        if (targetObject != null)
        {
            Vector3 newScale = targetObject.transform.localScale;
            newScale.x = newScaleXY;
            newScale.y = newScaleXY;
            targetObject.transform.localScale = newScale;
            UpdateScaleText();
        }
    }
    

    // Update the text displaying the current scale values
    private void UpdateScaleText()
    {
        if (targetObject != null)
        {
            scaleText.text = targetObject.transform.localScale.x.ToString("F2");
        }
    }
}
