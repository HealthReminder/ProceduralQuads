using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommonEvents : MonoBehaviour
{
    public UnityEvent[] OnAwakeEvents;

    public UnityEvent[] OnUpdateEvents;
    void Awake()
    {
        foreach (UnityEvent ue in OnAwakeEvents)
            ue.Invoke();
    }
    void Update()
    {
        foreach (UnityEvent ue in OnUpdateEvents)
            ue.Invoke();
    }
}
