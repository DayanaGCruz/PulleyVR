using TMPro;
using UnityEngine;

public class DistanceDisplay : MonoBehaviour
{
    public string compareTag;  // Tag of the pulley object
    public string weightTag;   // Tag of the weight object
    public TMP_Text distanceText;  // Text component to display the distance

    void Update()
    {
        // Find objects with the specified tags
        GameObject pulley = GameObject.FindGameObjectWithTag(compareTag);
        GameObject weight = GameObject.FindGameObjectWithTag(weightTag);

        // Check if both objects are found
        if (pulley != null && weight != null)
        {
            // Calculate the distance between pulley and weight
            Vector3 distanceVector = pulley.transform.position - weight.transform.position;

            // Display the distance in the UI text for X, Y, and Z coordinates
            Debug.Log($"{compareTag}-{weightTag} Distance:\nX: {distanceVector.x:F2}\nY: {distanceVector.y:F2}\nZ: {distanceVector.z:F2}");
            distanceText.text = $"{compareTag}-{weightTag} Distance:\nX: {distanceVector.x:F2}\nY: {distanceVector.y:F2}\nZ: {distanceVector.z:F2}";
        }
        else
        {
            // If one or both objects are not found, display an error message
            distanceText.text = "Objects not found!";
        }
    }
}