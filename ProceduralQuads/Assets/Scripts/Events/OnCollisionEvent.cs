using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class VectorEvent : UnityEvent<Vector3>
{
}
[System.Serializable]
public class RigidbodyEvent : UnityEvent<Rigidbody>
{
}
public class OnCollisionEvent : MonoBehaviour
{
    [Tooltip("Minimum impact magnitude to trigger events")]
    public float MinimumImpactMagnitude = 2;
    [Header("Regular Events")][Tooltip("Events that pass no parameters")]
    public List<UnityEvent> Events;
    [Header("Collision Position Events")][Tooltip("Events that pass the position of the collision as a parameter")]
    public List<VectorEvent> Vector3Events;
    [Header("Colliding Rigidbody Events")][Tooltip("Events that pass the colliding rigidbody as a parameter")]
    public List<RigidbodyEvent> RigidbodyEvents;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > MinimumImpactMagnitude)
        {
            Debug.Log(collision.relativeVelocity.magnitude);
            foreach (UnityEvent e in Events)
                e.Invoke();
            foreach (VectorEvent e in Vector3Events)
                e.Invoke(collision.GetContact(0).point);
            foreach (RigidbodyEvent e in RigidbodyEvents)
                e.Invoke(GetComponent<Rigidbody>());


        }
    }
}
