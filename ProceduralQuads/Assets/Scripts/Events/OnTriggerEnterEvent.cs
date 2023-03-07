using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public bool IsOnlyTriggeredByPlayer = false;
    public List<VectorEvent> VectorEvents;
    public List<RigidbodyEvent> RigidbodyEvents;
    private void OnTriggerEnter(Collider other)
    {
        if (IsOnlyTriggeredByPlayer)
        {
            if (other.tag == "Player")
                InvokeAll(other);
        } else
        {
            InvokeAll(other);
        }
                
    }
    private void InvokeAll(Collider col)
    {
        foreach (VectorEvent ev in VectorEvents)
        {
            ev.Invoke(col.ClosestPoint(transform.position));
        }
        foreach (RigidbodyEvent ev in RigidbodyEvents)
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
                ev.Invoke(rb);
        }
    }

}
