using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachFromParentBehaviour : MonoBehaviour
{
    public void Detach () {
        transform.parent = transform.parent.parent;
    }
}
