using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSequence : MonoBehaviour
{
    [System.Serializable]   public struct TimedEvent
    {
        public float DelayBefore;
        public UnityEvent Events;
        public float DelayAfter;
    }
    [SerializeField] private TimedEvent[] _timedEvents;
    private bool _isReady = true;   // If true initiate the event cascade
    private void Update()
    {
        if (_isReady)
        {
            _isReady = false;
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        for (int i = 0; i < _timedEvents.Length; i++)
        {
            TimedEvent e = _timedEvents[i];
            yield return new WaitForSeconds(e.DelayBefore);
            e.Events.Invoke();
            yield return new WaitForSeconds(e.DelayAfter);


        }
        yield break;
    }
}
