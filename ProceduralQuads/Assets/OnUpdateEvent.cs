using UnityEngine;
using UnityEngine.Events;

public class OnUpdateEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _events;
    public void Update()
    {
        _events.Invoke();
    }
}
