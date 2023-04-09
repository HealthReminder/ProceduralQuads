using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChangeSmooth : MonoBehaviour
{
    public bool IsStartInvisible = true;
    public bool IsInverse { get; set; }
    public bool IsChanging { get; set; }
    [SerializeField] private float _scaleMultiplier = 1; // Multiplies the animation curve
    [SerializeField] private AnimationCurve _scaleCurve; // Curve dictates the scale variation
    [SerializeField] private float _speed; // Movement progress, where it is in the movement
    float progress = 0; // Movement progress, where it is in the movement
    private void Start()
    {
        if (IsStartInvisible)
            transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        if (!IsChanging)
            return;

        // Advance in animation curve
        float t = Time.deltaTime * _speed;
        if (IsInverse)
            t *= -1;

        progress += Time.deltaTime * _speed;
        Mathf.Clamp01(progress);
        t = _scaleCurve.Evaluate(progress)* _scaleMultiplier;

        // Change scale accordingly
        transform.localScale = new Vector3(t, t, t);
    }
}