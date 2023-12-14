using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public string colliderTag = "none";
    //public Vector3 checkBoxSize = new Vector3(1f, 1f, 1f);

    private void Start()
    {
        Bounds checkBoxBounds = new Bounds(transform.position, transform.localScale);

        // Check for collisions in the specified area
        Collider[] colliders = Physics.OverlapBox(checkBoxBounds.center, checkBoxBounds.extents);
        foreach (Collider collider in colliders) { if (collider.gameObject.tag != null && collider.gameObject.tag != transform.gameObject.tag) { colliderTag = collider.gameObject.tag; } }
      
    }
    void OnCollisionEnter(Collision collision)
    {
        colliderTag = collision.gameObject.tag;
    }

    private void OnCollisionStay(Collision collision)
    {
        colliderTag = collision.gameObject.tag;
    }
 
    void OnCollisionExit(Collision collision)
    {
        colliderTag = "none";
    }
}
