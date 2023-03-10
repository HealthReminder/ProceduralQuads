using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraBackground : MonoBehaviour
{
    public Gradient PossibleColors;
    public void ChangeBackground()
    {
        GetComponent<Camera>().backgroundColor = PossibleColors.Evaluate(Random.Range(0.0f, 1.0f));
    }
}
