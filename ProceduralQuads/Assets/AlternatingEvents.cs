using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Invokes events in alternation
/// </summary>
public class AlternatingEvents : MonoBehaviour
{
    public bool IsLooping
    {
        get { return IsLooping; }
        set
        {

            if (value == false)
               _aEvents.Invoke();
            
            IsLooping = value;
        }
    }
    [SerializeField]  private UnityEvent _aEvents;
    [SerializeField]  private float _aDelay;

    [SerializeField]  private UnityEvent _bEvents;
    [SerializeField] private float _bDelay;


    private bool _isA = true;
    private float progress = 0;
    private void Update()
    {
        progress += Time.deltaTime;
        if(_isA)
        {
            if(progress >= _aDelay)
            {
                _isA = false;
                progress = 0;
                _bEvents.Invoke();
            }
        } else
        {
            if (progress >= _bDelay)
            {
                _isA = true;
                progress = 0;
                _aEvents.Invoke();
            }
        }
    }
}
