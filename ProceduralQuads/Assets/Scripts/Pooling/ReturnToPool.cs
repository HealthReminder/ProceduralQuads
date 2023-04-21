using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Invokes an event passing a transform as a parameter
/// </summary>
[System.Serializable]
public class TransformEvent : UnityEvent<Transform>
{
}
/// <summary>
/// Returns a transform to its pool
/// Pooling object must be selected in OnReturn event
/// Return() function should be called when desired
/// </summary>
public class ReturnToPool : MonoBehaviour
{
    [SerializeField] private TransformEvent _onReturn;
    public void Return()
    {
        _onReturn.Invoke(transform);
    }
}