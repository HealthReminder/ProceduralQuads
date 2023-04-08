using UnityEngine;

public class LookAtInterval : MonoBehaviour
{
    public float LookInterval = 0.1f; // Interval at which to update the object's look direction

    [SerializeField] private Transform _playerTransform; // Reference to the player's transform
    private float timeSinceLastLook; // Time since the object last looked at the player

    private void Start()
    {
        //Betters performance
        timeSinceLastLook = Random.Range(0, LookInterval);
        if(!_playerTransform)
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        // Check if it's time to update the object's look direction
        if (Time.time - timeSinceLastLook >= LookInterval)
        {
            // Look at the player
            transform.LookAt(_playerTransform.position);
            // Reset the timer
            timeSinceLastLook = Time.time;
        }
    }
}