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
    public float MinimumImpactMagnitude = 2;
    public List<UnityEvent> Events;
    public List<VectorEvent> VectorEvents;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > MinimumImpactMagnitude)
        {
            Debug.Log(collision.relativeVelocity.magnitude);
            foreach (VectorEvent e in VectorEvents)
                e.Invoke(collision.GetContact(0).point);
            foreach (UnityEvent e in Events)
                e.Invoke();

        }
    }
}
