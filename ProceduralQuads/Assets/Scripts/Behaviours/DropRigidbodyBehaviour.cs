using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRigidbodyBehaviour : MonoBehaviour
{
    public bool IsDropOnStart = false;
    public Rigidbody[] DroppingObjects;
    public void Drop()
    {
        foreach (Rigidbody rb in DroppingObjects)
        {
            rb.isKinematic = false;
        }
    }
}
