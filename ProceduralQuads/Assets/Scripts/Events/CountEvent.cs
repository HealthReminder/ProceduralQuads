using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountEvent : MonoBehaviour
{
    [Tooltip("At what number the event will trigger")]
    public int TriggerThreshold = 0;
    private int _currentCount = 0;
    public UnityEvent[] Events;
    public void Add()
    {
        _currentCount++;
        if (_currentCount >= TriggerThreshold)
            InvokeAll();
    }
    public void Remove()
    {
        _currentCount--;
    }
    public void InvokeAll()
    {
        foreach (UnityEvent e in Events)
        {
            e.Invoke();
        }
    }
}
