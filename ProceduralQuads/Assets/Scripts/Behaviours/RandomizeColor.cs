using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour
{
    public Renderer[] Renderers;
    public Gradient PossibleColors;
    public void Randomize()
    {
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        foreach (Renderer r in Renderers)
        {
            r.GetPropertyBlock(props);
            props.SetColor("_Color", PossibleColors.Evaluate(Random.Range(0.0f, 1.0f)));
            r.SetPropertyBlock(props);
        }
    }
}
