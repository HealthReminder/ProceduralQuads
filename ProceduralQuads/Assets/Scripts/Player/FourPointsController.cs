using UnityEngine;
using System.Linq;

public class FourPointsController : MonoBehaviour
{
    public Camera cam;
    public GameObject pointPrefab;
    public GameObject[] pointObjects = new GameObject[4];
    public float maxDistance = 30f;

    private Vector3[] points = new Vector3[4];
    private int pointCount = 0;
    private Vector3 centroid = Vector3.zero;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (pointCount < 4)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
                {
                    Vector3 point = hit.point;
                    points[pointCount] = point;
                    pointCount++;

                    // move the corresponding point object to the new point
                    pointObjects[pointCount - 1].transform.position = point;

                    // update the centroid
                    centroid = CalculateCentroid();
                }
            }
            else
            {
                // if we already have four points, reset and start over
                ResetPoints();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            ResetPoints();
        }
    }

    void ResetPoints()
    {
        pointCount = 0;
        foreach (GameObject pointObject in pointObjects)
        {
            pointObject.transform.position = new Vector3(0, -100, 0); // move the point object out of view
        }
        centroid = Vector3.zero; // reset the centroid
    }

    public Vector3[] GetPoints()
    {
        // calculate the centroid
        Vector3 center = CalculateCentroid();

        // calculate the normal of the plane
        Vector3 normal = Vector3.Cross(points[1] - points[0], points[2] - points[0]).normalized;

        // sort the points in clockwise order around the normal vector
        return points.OrderBy(p => -Vector3.SignedAngle(normal, p - center, Vector3.up)).ToArray();
    }
    Vector3 CalculateCentroid()
    {
        Vector3 centroid = Vector3.zero;
        for (int i = 0; i < points.Length; i++)
        {
            centroid += points[i];
        }
        return centroid / points.Length;
    }

    void Awake()
    {
        // instantiate the point objects
        for (int i = 0; i < pointObjects.Length; i++)
        {
            GameObject pointObject = Instantiate(pointPrefab, new Vector3(0, -100, 0), Quaternion.identity);
            pointObjects[i] = pointObject;
        }
    }
}