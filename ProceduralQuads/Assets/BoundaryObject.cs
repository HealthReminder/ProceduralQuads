using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryObject : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<CircleBoundary>().AddTransform(transform);
    }
}
