using UnityEngine;

public class RandomizeYPosition : MonoBehaviour
{
    public float MinimumYPosition;
    public Vector2 RandomYRange;
    public void Randomize()
    {
        transform.position += (transform.up * MinimumYPosition) + (transform.up * Random.Range(RandomYRange.x, RandomYRange.y));
    }
}
