using UnityEngine;

public class RotateRandomAxis : MonoBehaviour
{
    public bool IsRotating;
    public Vector3 rotationAxis = Vector3.up; // the axis to rotate around
    public float rotationSpeed = 10f; // the speed of rotation
    public float direction = 1f; //If it should rotate the other way (-1,1)

    public float offset = 0.5f; // the offset for oscillation
    public float oscillationSpeed = 1f; // the speed of oscillation

    private Vector3 originalRotationAxis; // original rotation axis

    void Start()
    {
        originalRotationAxis = rotationAxis.normalized; // store the original rotation axis normalized
    }

    void Update()
    {
        if (!IsRotating)
            return;
        // Calculate the oscillating rotation axis
        float oscillationX = Mathf.Sin(Time.time * oscillationSpeed) * offset;
        float oscillationY = Mathf.Sin(Time.time * oscillationSpeed + 1f) * offset;
        float oscillationZ = Mathf.Sin(Time.time * oscillationSpeed + 2f) * offset;
        Vector3 oscillation = new Vector3(oscillationX, oscillationY, oscillationZ);

        // Combine the original rotation axis with the oscillation
        rotationAxis = originalRotationAxis + oscillation;

        // Rotate the object
        transform.Rotate(rotationAxis, rotationSpeed * direction * Time.deltaTime);
    }
}