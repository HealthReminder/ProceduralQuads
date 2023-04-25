using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class ImpactEvent : UnityEvent<(float, Vector3)>
{
}
public class OnCollisionEvent : MonoBehaviour
{
    [Tooltip("Minimum impact magnitude to trigger events")]
    public float MinimumImpactMagnitude = 2;
    [Header("Regular Events")]
    [Tooltip("Events that pass no parameters")]
    public UnityEvent Events;
    [Tooltip("Events that pass the position and magnitude of collision an as a parameter")]
    public ImpactEvent ImpactEvents;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > MinimumImpactMagnitude)
        {
            //Debug.Log(collision.relativeVelocity.magnitude);
            Events.Invoke();
            ImpactEvents.Invoke((collision.relativeVelocity.magnitude,collision.GetContact(0).point));


        }
    }
}
