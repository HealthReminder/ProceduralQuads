using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExitEvent : MonoBehaviour
{
    public string TriggerTag;
    public List<UnityEvent> RegularEvents;
    public List<VectorEvent> VectorEvents;
    public List<RigidbodyEvent> RigidbodyEvents;

    void OnTriggerExit(Collider other)
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
        foreach (UnityEvent ev in RegularEvents)
        {
            ev.Invoke();
        }
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
