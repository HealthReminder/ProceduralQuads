using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Oscillates position in between start position and offset vector
/// </summary>
public class OscillatePosition : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private AnimationCurve _movementCurve;

    // Variables to control oscillation behavior
    [SerializeField] private float _speed = 1.0f;  // Frequency of oscillation
    [SerializeField] private float _multiplier = 1.0f;  // Amplitude of oscillation

    private Vector3 initialPosition;  // Initial position of the object

    private void Start()
    {
        initialPosition = transform.localPosition;  // Store the initial position of the object
    }

    private void Update()
    {
        // Calculate the new position of the object based on time, frequency, and amplitude
        float s = _movementCurve.Evaluate(Mathf.Sin(Time.time * _speed)) * _multiplier;
        Vector3 newPosition = initialPosition + _offset * s;

        transform.localPosition = newPosition;  // Set the new position of the object
    }
}