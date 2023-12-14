using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InfoDisplay : MonoBehaviour
{
    public GameObject mass;
    public TMP_Text velocityxText;
    public TMP_Text velocityyText;
    public TMP_Text velocityzText;
    public TMP_Text accxText;
    public TMP_Text accyText;
    public TMP_Text acczText;
    public TMP_Text velocityMagnitudeText;
    public TMP_Text accelerationMagnitudeText; 
    private Rigidbody rgb;
    private Vector3 velocity;

    void Start()
    {
        rgb = mass.GetComponent<Rigidbody>();
        if (rgb == null) { Debug.Log("Rigidbody is null"); }
        velocity = rgb.velocity;
    }

    void FixedUpdate()
    {
        Vector3 acceleration = (rgb.velocity - velocity) / Time.fixedDeltaTime;
        velocity = rgb.velocity;

        // Update individual components of velocity and acceleration
        velocityxText.text = velocity.x.ToString("F4");
        velocityyText.text = velocity.y.ToString("F4");
        velocityzText.text = velocity.z.ToString("F4");
        accxText.text = acceleration.x.ToString("F4");
        accyText.text = acceleration.y.ToString("F4");
        acczText.text = acceleration.z.ToString("F4");

        // Calculate and update magnitude of velocity and acceleration
        float velocityMagnitude = velocity.magnitude;
        float accelerationMagnitude = acceleration.magnitude;

        velocityMagnitudeText.text = velocityMagnitude.ToString("F4");
        accelerationMagnitudeText.text = accelerationMagnitude.ToString("F4");
    }
}