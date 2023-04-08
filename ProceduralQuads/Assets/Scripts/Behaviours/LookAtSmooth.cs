using UnityEngine;

/// <summary>
/// This class gradually rotates an object in the direction of the other
/// </summary>
public class LookAtSmooth : MonoBehaviour
{
    public float LookSpeed = 0.1f; // Interval at which to update the object's look direction
    public bool IsLooking { get; set; }
    [SerializeField] private Transform _lookingAt; // Reference to the transform being looked at

    private void Start()
    {
        // Betters performance
        if (!_lookingAt)
            _lookingAt = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if it's time to update the object's look direction
        if (IsLooking)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_lookingAt.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, LookSpeed * Time.deltaTime);
        }
    }
}