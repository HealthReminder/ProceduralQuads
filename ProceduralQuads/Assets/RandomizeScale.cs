using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeScale : MonoBehaviour
{
    public Vector2 ScaleRandomRange;
    public void Randomize()
    {
        transform.localScale *= Random.Range(ScaleRandomRange.x, ScaleRandomRange.y);
    }
}
