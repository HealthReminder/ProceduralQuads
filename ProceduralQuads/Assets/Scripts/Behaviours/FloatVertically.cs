using UnityEngine;

public class FloatVertically : MonoBehaviour
{
    public float yVariation = 1f; // how much Y variation there will be
    public float speed = 1f; // how fast the motion should be
    private float _timeOffset; //Randomize a time offset on start

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        _timeOffset = Random.Range(0, 60);
    }

    public void Float()
    {
        float y = startPosition.y + yVariation * Mathf.Sin(Time.time * speed + _timeOffset);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}