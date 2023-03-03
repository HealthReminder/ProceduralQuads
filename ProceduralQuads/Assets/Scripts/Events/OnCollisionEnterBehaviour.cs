using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class VectorEvent : UnityEvent<Vector3>
{
}
public class OnCollisionEnterBehaviour : MonoBehaviour
{
    public float MinimumImpactMagnitude = 2;
    public List<VectorEvent> Events;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > MinimumImpactMagnitude)
        {
            Debug.Log(collision.relativeVelocity.magnitude);
            foreach (VectorEvent e in Events)
                e.Invoke(collision.GetContact(0).point);
        }
    }
}
