using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpiral : MonoBehaviour
{
    public GameObject prefabToSpawn; // the prefab to spawn
    public int numObjectsToSpawn; // the number of objects to spawn
    public float radius; // the radius of the spiral
    public float height; // the height of the spiral
    public float spiralAnglePerObject; // the angle between each object in the spiral
    public float objectSeparation; // the distance between each object in the spiral

    void Start()
    {
        for (int i = 0; i < numObjectsToSpawn; i++)
        {
            float angle = i * spiralAnglePerObject;
            float x = radius * Mathf.Cos(angle);
            float y = i * objectSeparation;
            float z = radius * Mathf.Sin(angle);

            Vector3 spawnPos = new Vector3(x, y, z) + transform.position;
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity, transform);
        }
    }
}