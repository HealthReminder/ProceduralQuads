using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // the axis to rotate around
    public float rotationSpeed = 10f; // the speed of rotation
    
    public float direction; //If it should rotate the other way (-1,1)
    public void Rotate()
    {
        transform.Rotate(rotationAxis, rotationSpeed * direction * Time.deltaTime);
    }
}