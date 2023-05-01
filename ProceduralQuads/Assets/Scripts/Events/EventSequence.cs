using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EventSequence : MonoBehaviour
{

    public bool IsReady { get => _isReady; set => _isReady = value; }
    public float TimeMultiplier { get => _timeMultiplier; set => _timeMultiplier = value; }
    public bool HasTriggered { get => _hasTriggered; set => _hasTriggered = value; }
    [SerializeField] private bool _isReady = true;   // If true iniates event sequence
    [SerializeField] private bool _hasTriggered = false;   // If true initiate the event cascade
    [SerializeField] private float _timeMultiplier = 1.0f; // Multiplies the time waited between events
    int currentEvent = 0;
    [System.Serializable]   public struct TimedEvent
    {
        public string Name;
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
            StartCoroutine(AllSequenceRoutine());
        }
    }
    public void NextEvent()
    {
        StartCoroutine(SequenceRoutine(_timedEvents[currentEvent]));
    }
    IEnumerator SequenceRoutine(TimedEvent e)
    {
        currentEvent++;
        if (currentEvent >= _timedEvents.Length)
            yield break;

        yield return new WaitForSeconds(e.DelayBefore * _timeMultiplier);
        e.Events.Invoke();
        Debug.Log(e.Name + " event triggered by " + gameObject.name);
        yield return new WaitForSeconds(e.DelayAfter * _timeMultiplier);
    }
    IEnumerator AllSequenceRoutine()
    {
        for (int i = currentEvent; i < _timedEvents.Length; i++)
        {
            TimedEvent e = _timedEvents[i];
            yield return SequenceRoutine(e);
        }
        yield break;
    }
}
