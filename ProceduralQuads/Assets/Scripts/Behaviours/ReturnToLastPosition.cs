using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToLastPosition : MonoBehaviour
{
    private Transform _lastTransform;
    private Vector3 _lastPosition = new Vector3(-1, -1, -1);

    float rayDelay = 1.0f;
    float currentTime = 0.0f;
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>= rayDelay)
        {
            currentTime = 0;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.up * -1, out hit, 1.5f))
            {
                if (hit.transform)
                {
                    if(hit.transform != transform)
                    {
                        _lastTransform = hit.transform;
                        _lastPosition = hit.point;
                    }
                }
            }
        }
       
    }
    public void ReturnToPosition()
    {
        if (_lastPosition == Vector3.one * -1)
            return;

        transform.position = _lastPosition + Vector3.up;
    }
}
