using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExitEvent : MonoBehaviour
{
    public string TriggerTag;
    public UnityEvent RegularEvents;
    public ImpactEvent ImpactEvents;

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
        RegularEvents.Invoke();
        ImpactEvents.Invoke((1,col.ClosestPoint(transform.position)));
    }

}
