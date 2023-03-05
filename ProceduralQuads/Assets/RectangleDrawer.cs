using UnityEngine;

public class RectangleDrawer: MonoBehaviour
{
    public GameObject cornerPrefab;
    public Material lineMaterial;
    private GameObject[] corners;
    private LineRenderer lineRenderer;

    public void Awake()
    {
        // Create the corner objects
        corners = new GameObject[4];
        for (int i = 0; i < corners.Length; i++)
        {
            corners[i] = GameObject.Instantiate(cornerPrefab);
            corners[i].SetActive(false);
        }

        // Get the line renderer
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Draw the rectangle
    public void Draw(Vector3[] points)
    {
        if (points.Length != 4)
        {
            Debug.LogError("Cannot draw rectangle with less or more than four points.");
            return;
        }

        // Enable the corner objects and set their positions
        for (int i = 0; i < corners.Length; i++)
        {
            corners[i].SetActive(true);
            corners[i].transform.position = points[i];
        }

        // Set the LineRenderer positions
        lineRenderer.enabled = true;
        for (int i = 0; i < 12; i++)
        {
            lineRenderer.SetPosition(i, points[0]);

        }
        lineRenderer.positionCount = 12;

        lineRenderer.SetPosition(0, points[0]);
        lineRenderer.SetPosition(1, points[1]);
        lineRenderer.SetPosition(2, points[3]);

        lineRenderer.SetPosition(3, points[1]);
        lineRenderer.SetPosition(4, points[2]);
        lineRenderer.SetPosition(5, points[0]);

        lineRenderer.SetPosition(6, points[2]);
        lineRenderer.SetPosition(7, points[3]);
        lineRenderer.SetPosition(8, points[1]);

        lineRenderer.SetPosition(9, points[3]);
        lineRenderer.SetPosition(10, points[0]);
        lineRenderer.SetPosition(11, points[2]);
    }
    // Erase the rectangle
    public void Erase()
    {
        // Disable the corner objects and the line renderer
        foreach (GameObject corner in corners)
        {
            corner.SetActive(false);
        }
        lineRenderer.enabled = false;
    }
}