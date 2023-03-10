using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occludee : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<FrustumCulling>().AddRenderer(GetComponent<Renderer>());
    }
}
