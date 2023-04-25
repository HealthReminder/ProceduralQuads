using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public string TriggerTag;
    public bool isOnlyTriggeredOnce = false;
    public UnityEvent RegularEvents;
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
        if (isOnlyTriggeredOnce == true)
            Destroy(gameObject);
    }

}
