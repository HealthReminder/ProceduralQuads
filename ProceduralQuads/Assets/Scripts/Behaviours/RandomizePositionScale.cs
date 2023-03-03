using System.Collections;
using UnityEngine;


public class RandomizePositionScale : MonoBehaviour
{
    [Header("Random properties")]
    public float RadiusSpawn = 5f; // the radius in which to randomize the object's position
    public Vector2 Yrange; // the minimum and maximum y value for the object's position
    public Vector2 SizeRange; // the minimum and maximum size for the object

    private Vector3 _originalScale; // the original scale of the object


    internal bool _isTouched = false;

    public void Randomize()
    {
        _originalScale = transform.localScale;
        RandomizePosition();
        RandomizeSize();
    }
    private void RandomizePosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * RadiusSpawn;
        transform.position = new Vector3(randomCircle.x, Random.Range(Yrange.x, Yrange.y), randomCircle.y);
    }

    private void RandomizeSize()
    {
        float randomSize = Random.Range(SizeRange.x, SizeRange.y);
        transform.localScale = _originalScale * randomSize;
    }
}