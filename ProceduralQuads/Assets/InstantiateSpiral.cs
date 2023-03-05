using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpiral : MonoBehaviour
{
    public Transform SpiralPivot;
    public GameObject Prefab; // the prefab to spawn
    public int ObjectCount; // the number of objects to spawn
    public float Radius; // the radius of the spiral
    public float Height; // the height of the spiral
    public float SpiralAnglePerObject; // the angle between each object in the spiral
    public float ObjectSeparation; // the distance between each object in the spiral
 

    public void Instantiate()
    {
        for (int i = 0; i < ObjectCount; i++)
        {
            float angle = i * SpiralAnglePerObject;
            float x = Radius * Mathf.Cos(angle);
            float y = i * ObjectSeparation;
            float z = Radius * Mathf.Sin(angle);

            Vector3 spawnPos = new Vector3(x, y, z) + transform.position;
            GameObject spawnedObject = Instantiate(Prefab, spawnPos, Quaternion.identity, SpiralPivot);
            spawnedObject.SetActive(true);
        }
    }
}