using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public bool IsOnlyTriggeredByPlayer = false;
    public bool isOnlyTriggeredOnce = false;
    public List<UnityEvent> RegularEvents;
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
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
                ev.Invoke(rb);
        }
        if (isOnlyTriggeredOnce == true)
            Destroy(gameObject);
    }

}
