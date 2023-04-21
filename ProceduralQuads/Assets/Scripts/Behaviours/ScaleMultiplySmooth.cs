using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Change the scale of an object smoothly
/// </summary>
public class ScaleMultiplySmooth : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleMultiplier;  // Multiplies the local scale of the object
    [SerializeField] private float _speed = 1.0f;   // How fast the object changes scale
    [SerializeField] private AnimationCurve _scaleCurve;    // Curve dictates the scaling
   
    /// <summary>
    /// Calls the change scale routine for smooth scaling
    /// </summary>
    [ContextMenu("Change Scale")]
    public void MultiplyScale()
    {
        StartCoroutine(MultiplyScaleRoutine());
    }
    /// <summary>
    /// Smoothly change the object local scale by the scale multiplier
    /// </summary>
    IEnumerator MultiplyScaleRoutine()
    {
        Vector3 startScale = transform.localScale;
        Vector3 finalScale = Vector3.Scale(transform.localScale, _scaleMultiplier);
        float progress = 0;
        while (progress < 1)
        {
            transform.localScale = Vector3.Lerp(startScale, finalScale, _scaleCurve.Evaluate(progress));
            progress += Time.deltaTime * _speed;
            yield return null;
        }
        transform.localScale = finalScale;
        yield break;
    }
}
