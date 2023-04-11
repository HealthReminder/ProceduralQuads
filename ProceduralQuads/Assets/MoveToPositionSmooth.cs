using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositionSmooth : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private AnimationCurve _movementCurve;
    private Vector3 _initialPosition;
    public void MoveToPosition()
    {
        StartCoroutine(MoveRoutine());
    }
    private IEnumerator MoveRoutine()
    {
        _initialPosition = transform.localPosition;

        float progress = 0;
        while (progress <= 1)
        {
            transform.localPosition = Vector3.Lerp(_initialPosition, _offsetPosition, _movementCurve.Evaluate(progress));
            progress += Time.deltaTime*_speed;
            yield return null;
        }
        transform.localPosition = _offsetPosition;
        yield break;
    }
}
