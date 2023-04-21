using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is used to manipulate the properties of a shader
/// </summary>
public class ChangeShadersPropertySmooth : MonoBehaviour
{
    [SerializeField] private string _propertyName;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private AnimationCurve _changeCurve;
    [SerializeField] private Renderer[] _renderers;

    [ContextMenu("Change Properties")]
    public void ChangeProperties(float targetValue)
    {
        StartCoroutine(ChangePropertiesRoutine(targetValue));
    }
    IEnumerator ChangePropertiesRoutine(float targetValue)
    {
        // Get initial values
        int l = _renderers.Length;
        float[] initialValues = new float[l];
        for (int i = 0; i < l; i++)
            _renderers[i].material.GetFloat(_propertyName);

        // Smoothly set float property for the material
        float progress = 0;
        while(progress < 1)
        {
            for (int i = 0; i < l; i++)
                _renderers[i].material.SetFloat(_propertyName, Mathf.Lerp(initialValues[i], targetValue, _changeCurve.Evaluate(progress)));
            progress += Time.deltaTime* _speed;
            yield return null;
        }
        for (int i = 0; i < l; i++)
            _renderers[i].material.SetFloat(_propertyName, targetValue);


        yield break;
    }
}
