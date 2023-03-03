using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Vector3 forces;
    public float forceMultiplier;
    public void Add()
    {
        GetComponent<Rigidbody>().AddRelativeForce(forces * forceMultiplier, ForceMode.Impulse);
    }
}
