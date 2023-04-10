using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookAtEvent : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Renderer _targetLookAt;
    [SerializeField] private UnityEvent _onLooking;
    private bool _isTriggered = false;


    private void Update()
    {
        if (_isTriggered)
            return;
        // Check if the targetLookAt transform is visible within the camera frustum
        if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_playerCamera), _targetLookAt.bounds))
        {
            _isTriggered = true;
            _onLooking.Invoke();
        }
    }
}
