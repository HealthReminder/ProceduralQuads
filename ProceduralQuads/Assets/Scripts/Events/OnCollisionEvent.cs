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
    [Tooltip("Tag that triggers collision. Empty for everything")]
    public string Tag;
    [Tooltip("Check if collider can only be triggered once")]
    public bool IsTriggeredOnce = false;
    [Tooltip("Minimum impact magnitude to trigger events")]
    public float MinimumImpactMagnitude = 2;
    [Header("Regular Events")]
    [Tooltip("Events that pass no parameters")]
    public UnityEvent Events;
    [Tooltip("Events that pass the position and magnitude of collision an as a parameter")]
    public ImpactEvent ImpactEvents;

    bool hasTriggered = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > MinimumImpactMagnitude)
        {
            if(!IsTriggeredOnce || (IsTriggeredOnce && !hasTriggered))
            if (tag == string.Empty || (tag != string.Empty && collision.transform.tag == Tag))
            {
                Events.Invoke();
                ImpactEvents.Invoke((collision.relativeVelocity.magnitude, collision.GetContact(0).point));
                    hasTriggered = true;
            }
        }
    }
}
