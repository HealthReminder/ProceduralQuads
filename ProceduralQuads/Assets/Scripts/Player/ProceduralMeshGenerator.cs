using System.Collections.Generic;
using UnityEngine;

public class ProceduralMeshGenerator : MonoBehaviour
{
    public Material propBlockMaterial; // Material to use for the object's texture
    private List<GameObject> generatedObjects = new List<GameObject>(); // List to store generated objects
    public Gradient PossibleColorGradient;

    // Method to generate the object using four points in world space
    public void Generate(Vector3[] points)
    {
        // Check that the points array has length of 4
        if (points.Length != 4)
        {
            Debug.LogError("Invalid number of points. Expected 4, but received " + points.Length);
            return;
        }

        // Create a new game object and add a mesh renderer and mesh filter component to it
        GameObject newObject = new GameObject();
        newObject.AddComponent<MeshRenderer>();
        newObject.AddComponent<MeshFilter>();
        newObject.AddComponent<MeshCollider>();
        newObject.GetComponent<MeshCollider>().convex = true;

        // Assign the material to the object's mesh renderer
        newObject.GetComponent<MeshRenderer>().material = propBlockMaterial;
        newObject.GetComponent<MeshRenderer>().sharedMaterial = propBlockMaterial;

        // Create a new mesh and assign the vertices, triangles, normals, and UV mapping to it
        Mesh newMesh = new Mesh();
        newMesh = GenerateMesh(points);
        // Set the mesh for the object's mesh filter
        newObject.GetComponent<MeshFilter>().mesh = newMesh;

        // Update the mesh collider
        newObject.GetComponent<MeshCollider>().sharedMesh = newMesh;

        //Change color of the object
        ColorGeneratedObject(newObject.GetComponent<MeshRenderer>(), PossibleColorGradient.Evaluate(Random.Range(0.0f, 1.0f)));

        // Add the generated object to the list
        generatedObjects.Add(newObject);
    }
    private void ColorGeneratedObject(MeshRenderer renderer,Color NewColor)
    {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(block);
        block.SetColor("_Color", NewColor);
        block.SetColor("Color", NewColor);
        renderer.SetPropertyBlock(block,0);
        Debug.Log("Set property block");
        return;
    }
    private Mesh GenerateMesh(Vector3[] points)
    {
        Mesh newMesh = new Mesh();
        newMesh.vertices = new Vector3[] {
        points[0], points[1], points[2],
        points[1], points[3], points[2],
        points[2], points[3], points[0],
        points[3], points[1], points[0]
    };
        newMesh.triangles = new int[] {
        0, 1, 2,
        3, 4, 5,
        6, 7, 8,
        9, 10, 11
    };
        newMesh.normals = new Vector3[] {
        Vector3.forward, Vector3.forward, Vector3.forward,
        Vector3.forward, Vector3.back, Vector3.back,
        Vector3.back, Vector3.back, Vector3.back,
        Vector3.back, Vector3.forward, Vector3.forward
    };
        newMesh.uv = new Vector2[] {
        new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0),
        new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0),
        new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0),
        new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0)
    };
        return newMesh;
    }

}