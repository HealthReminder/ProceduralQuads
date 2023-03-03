using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTester : MonoBehaviour
{
    public ProceduralObjectGenerator ProceduralObjectGenerator;
    public FourPointsController FourPointsController;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            GeneratePlane();
     
    }
    private void GeneratePlane()
    {
        FourPointsController = GetComponent<FourPointsController>();
        Vector3[] points = FourPointsController.GetPoints();
        ProceduralObjectGenerator.Generate(points);
    }

}
