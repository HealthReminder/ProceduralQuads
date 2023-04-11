using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookAtTriggerEvent : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Renderer _targetLookAt;
    [SerializeField] private UnityEvent _onTriggerAndLooking;
    private bool _isTriggered = false;
    

    private void OnTriggerStay(Collider other)
    {
        if(!_isTriggered)
        {
            // Check if the targetLookAt transform is visible within the camera frustum
            if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_playerCamera), _targetLookAt.bounds))
            {
                _isTriggered = true;
                _onTriggerAndLooking.Invoke();
            }
        }
    }
}
