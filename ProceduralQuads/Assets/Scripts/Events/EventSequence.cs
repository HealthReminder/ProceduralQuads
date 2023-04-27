using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSequence : MonoBehaviour
{

    public bool IsReady { set => _isReady = value; }
    [SerializeField] private bool _isReady = true;   // If true ini
    [SerializeField] private bool _hasTriggered = false;   // If true initiate the event cascade
    [SerializeField] private float _timeMultiplier = 1.0f; // Multiplies the time waited between events
    [System.Serializable]   public struct TimedEvent
    {
        public float DelayBefore;
        public UnityEvent Events;
        public float DelayAfter;
    }
    [SerializeField] private TimedEvent[] _timedEvents;
    private void Update()
    {
        if (_isReady && !_hasTriggered)
        {
            _isReady = false;
            _hasTriggered = true;
            StartCoroutine(SequenceRoutine());
        }
    }
    IEnumerator SequenceRoutine()
    {
        for (int i = 0; i < _timedEvents.Length; i++)
        {
            TimedEvent e = _timedEvents[i];
            yield return new WaitForSeconds(e.DelayBefore* _timeMultiplier);
            e.Events.Invoke();
            yield return new WaitForSeconds(e.DelayAfter * _timeMultiplier);


        }
        yield break;
    }
}
