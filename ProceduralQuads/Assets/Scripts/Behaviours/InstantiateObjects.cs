using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public int ObjectCount;

    public void Instantiate()
    {
        for (int i = 0; i < ObjectCount; i++)
            Instantiate(ObjectPrefab, transform.position, Quaternion.identity, transform).gameObject.SetActive(true);
    }
}
