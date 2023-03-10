using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommonEvents : MonoBehaviour
{
    public UnityEvent[] OnAwakeEvents;
    public UnityEvent[] OnStartEvents;
    public UnityEvent[] OnUpdateEvents;
    void Awake()
    {
        foreach (UnityEvent ue in OnAwakeEvents)
            ue.Invoke();
    }
    void Start()
    {
        foreach (UnityEvent ue in OnStartEvents)
            ue.Invoke();
    }
    void Update()
    {
        foreach (UnityEvent ue in OnUpdateEvents)
            ue.Invoke();
    }
}
