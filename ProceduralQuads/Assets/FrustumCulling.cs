using System.Collections.Generic;
using UnityEngine;

public class FrustumCulling : MonoBehaviour
{
    private Camera _cam;
    private List<Renderer> _occludees;

    void Awake()
    {
        _cam = GetComponent<Camera>();
        _occludees = new List<Renderer>();
    }
    public void AddRenderer(Renderer newRenderer)
    {
        _occludees.Add(newRenderer);
    }

    void Update()
    {
        // Check if object is within camera frustum
        for (int i = 0; i < _occludees.Count; i++) {
            Renderer rend = _occludees[i];
            if (rend != null)
            {
                if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_cam), rend.bounds))
                {
                    rend.enabled = true; // Object is visible, so enable rendering
                }
                else
                {
                    rend.enabled = false; // Object is not visible, so disable rendering
                }
            }
        }
    }
}