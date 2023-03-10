using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountdownEvent : MonoBehaviour
{
    public float startingTime = 0.0f;
    public float maxTime = 0.0f;
    private float _currentTime = 0.0f;
    private bool _hasTriggered = false;
    public UnityEvent[] Events;
    private void Start()
    {
        _currentTime = startingTime;
    }
    public void AddTime(float time)
    {
        _currentTime += time;
        if (_currentTime > maxTime)
            _currentTime = maxTime;
    }
    private void Update()
    {
        _currentTime -= Time.deltaTime;
        if (!_hasTriggered)
        {
            if (_currentTime <= 0)
            {
                _hasTriggered = true;
                foreach (UnityEvent ev in Events)
                {
                    ev.Invoke();
                }
            }
        }
    }
}
