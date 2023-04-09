using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
    public bool IsRotating
    {
        get { return _isRotating; }
        set => IsRotating = value;
    }
    [SerializeField] private bool _isRotating;
    [SerializeField] private Vector3 _rotationAxis = Vector3.up; // the axis to rotate around
    [SerializeField] private float _rotationSpeed = 10f; // the speed of rotation

    [Range(-1, 1)] [SerializeField] private float _direction; //If it should rotate the other way (-1,1)
    private void Update()
    {
        if (!_isRotating)
            return;
        Rotate();
    }
    public void Rotate()
    {
        transform.Rotate(_rotationAxis, _rotationSpeed * _direction * Time.deltaTime);
    }
}