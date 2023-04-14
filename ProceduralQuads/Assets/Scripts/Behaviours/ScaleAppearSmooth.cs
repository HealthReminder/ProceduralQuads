using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAppearSmooth : MonoBehaviour
{
    public bool IsStartInvisible = true;
    public bool IsChanging { get; set; }
     private Vector3 _targetScale = Vector3.one; // Multiplies the animation curve
    [SerializeField] private AnimationCurve _scaleCurve; // Curve dictates the scale variation
    [SerializeField] private float _speed; // Movement progress, where it is in the movement
    float progress = 0; // Movement progress, where it is in the movement
    private void Start()
    {
        _targetScale = transform.localScale;

        if (IsStartInvisible)
            transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        if (!IsChanging)
            return;

        // Advance in animation curve
        float t = Time.deltaTime * _speed;

        progress += Time.deltaTime * _speed;
        Mathf.Clamp01(progress);
        t = _scaleCurve.Evaluate(progress);

        // Change scale accordingly
        transform.localScale = _targetScale * t;
    }
}