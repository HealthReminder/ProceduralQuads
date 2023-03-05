using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement Movement;
    public ProceduralMeshGenerator ProceduralObjectGenerator;
    public FourPointsController FourPointsController;
    public RectangleDrawer meshPreview;
    private Vector3[] currentPlane;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (FourPointsController.PointCount < 4)
            {
                FourPointsController.PlacePoint();
                //Erase the preview when starting a new mesh
                if (FourPointsController.PointCount == 1)
                    meshPreview.Erase();
                //When finished placing the four points, draw the preview lines
                if (FourPointsController.PointCount == 4)
                {
                    currentPlane = FourPointsController.GetPoints();
                    meshPreview.Draw(currentPlane);
                }
            }  //If there is a plane, generate it
            else if (currentPlane != null)
            {
                ProceduralObjectGenerator.Generate(FourPointsController.GetPoints());
                FourPointsController.ResetPoints();
                currentPlane = null;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            FourPointsController.ResetPoints();
            meshPreview.Erase();
        }
    }
}
