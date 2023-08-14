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
    [SerializeField] private bool _isTriggerNextEvent = false; // Enables triggering through the inspector
    int currentEvent = 0;
    [System.Serializable]
    public struct TimedEvent
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
        if (_isTriggerNextEvent)
        {
            _isTriggerNextEvent = false;
            NextEvent();
        }
    }
    public void NextEvent()
    {
        Debug.Log(currentEvent);
        if (currentEvent < _timedEvents.Length)
            StartCoroutine(SequenceRoutine(_timedEvents[currentEvent]));
    }

    IEnumerator AllSequenceRoutine()
    {
        for (int i = currentEvent; i < _timedEvents.Length; i++)
        {
            TimedEvent e = _timedEvents[i];
            Debug.Log(i);
            yield return SequenceRoutine(e);
        }
        yield break;
    }
    IEnumerator SequenceRoutine(TimedEvent e)
    {
        currentEvent++;
        Debug.Log("Event triggered: " + e.Name + ", triggered by " + gameObject.name);
        float timePassed = 0;
        float targetTime = e.DelayBefore * _timeMultiplier;
        Debug.Log("A1");
        while (timePassed<= targetTime)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("A2");
        e.Events.Invoke();
        timePassed = 0;
        targetTime = e.DelayAfter * _timeMultiplier;
        Debug.Log("A3");
        while (timePassed <= targetTime)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("A4");
        yield break;
    }
}
