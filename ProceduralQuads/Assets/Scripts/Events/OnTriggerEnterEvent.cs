using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public string TriggerTag;
    public bool isOnlyTriggeredOnce = false;
    public UnityEvent RegularEvents;
    public VectorEvent VectorEvents;
    public RigidbodyEvent RigidbodyEvents;
    private void OnTriggerEnter(Collider other)
    {
        if (TriggerTag == string.Empty)
        {
            InvokeAll(other);
        }
        else
        {
            if (other.tag == TriggerTag)
                InvokeAll(other);
        }


    }
    private void InvokeAll(Collider col)
    {
        RegularEvents.Invoke();

        VectorEvents.Invoke(col.ClosestPoint(transform.position));

        Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
            RigidbodyEvents.Invoke(rb);

        if (isOnlyTriggeredOnce == true)
            Destroy(gameObject);
    }

}
