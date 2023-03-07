using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachFromParentBehaviour : MonoBehaviour
{
    public bool IsOnce = true;
    private bool _hasDetached = false;
    public void Detach () {
        if (IsOnce && _hasDetached)
            return;

        transform.parent = transform.parent.parent;
        _hasDetached = true;
    }
}
