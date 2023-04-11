using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTransform : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    public void MoveTo(Rigidbody rb)
    {
        rb.transform.position = _targetTransform.position;
    }
    public void MoveTo(Transform t)
    {
        t.position = _targetTransform.position;
    }
}
