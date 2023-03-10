using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform PlayerTransform;

    private void LateUpdate()
    {
        // Only update the position
        transform.position = PlayerTransform.position;

        // Align rotation to target's Y axis
        Vector3 targetDir = PlayerTransform.forward;
        targetDir.y = 0f; // Zero out the Y component
        if (targetDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(targetDir);
        }
    }
}

