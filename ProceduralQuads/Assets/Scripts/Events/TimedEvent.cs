using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    public bool IsLoop = false;
    public float secondsToWait;
    public List<UnityEvent> Events;
    private bool _isReady = true;
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
        yield return new WaitForSeconds(secondsToWait);
        foreach (UnityEvent e in Events)
            e.Invoke();
        if (IsLoop)
            _isReady = true;
        yield break;
    }
}
