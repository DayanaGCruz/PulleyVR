using UnityEngine;

public class Trashcan : MonoBehaviour
{
    // This function is called when another object enters the trigger zone.
    private void OnTriggerEnter(Collider other)
    {
            // Destroy the entering object.
            Destroy(other.gameObject);
    }
}
