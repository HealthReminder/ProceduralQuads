using UnityEngine;

public class AutoLookAtBehaviour : MonoBehaviour
{
    public Transform ObservedTransform; // Reference to the player's transform
    public float LookInterval = 0.1f; // Interval at which to update the object's look direction

    private float timeSinceLastLook; // Time since the object last looked at the player

    private void Start()
    {
        //Betters performance
        timeSinceLastLook = Random.Range(0, LookInterval);
    }
    void Update()
    {
        // Check if it's time to update the object's look direction
        if (Time.time - timeSinceLastLook >= LookInterval)
        {
            // Look at the player
            transform.LookAt(ObservedTransform.position);
            // Reset the timer
            timeSinceLastLook = Time.time;
        }
    }
}