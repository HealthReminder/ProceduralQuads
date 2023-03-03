using UnityEngine;
using System.Collections.Generic;

public class CircleBoundary : MonoBehaviour
{
    public float radius = 5.0f; // radius of the circle boundary
    public List<Transform> objects = new List<Transform>(); // list of objects to be confined within the circle boundary

    // Update is called once per frame
    void Update()
    {
        foreach (Transform obj in objects)
        {
            // check if the object has moved outside of the circle boundary
            if (Vector3.Distance(obj.position, transform.position) > radius)
            {
                // calculate the new position of the object on the opposite side of the circle boundary
                Vector3 direction = obj.position - transform.position;
                direction.Normalize();
                Vector3 oldVelocity = obj.GetComponent<Rigidbody>().velocity;
                obj.position = transform.position - direction * radius;
                Vector3 newVelocity = obj.GetComponent<Rigidbody>().velocity;
                Vector3 velocityChange = newVelocity - oldVelocity;
            }
        }
    }
}