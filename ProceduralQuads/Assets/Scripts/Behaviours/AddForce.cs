using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Vector3 forces;
    public float forceMultiplier;
    public void AddForceToSelfRigidbody()
    {
        GetComponent<Rigidbody>().AddRelativeForce(forces * forceMultiplier, ForceMode.Impulse);
    }
    public void AddForceToOtherRigidbody(Rigidbody rb)
    {
        rb.AddRelativeForce(forces * forceMultiplier, ForceMode.Impulse);
    }
}
