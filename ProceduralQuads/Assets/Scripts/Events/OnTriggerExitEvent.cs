using System.Collections.Generic;
using UnityEngine;

public class OnTriggerExitEvent : MonoBehaviour
{
    public bool IsOnlyTriggeredByPlayer = false;
    public List<VectorEvent> VectorEvents;
    public List<RigidbodyEvent> RigidbodyEvents;

    void OnTriggerExit(Collider other)
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
            if(col.GetComponent<Rigidbody>())
                ev.Invoke(col.GetComponent<Rigidbody>());
        }
    }

}
