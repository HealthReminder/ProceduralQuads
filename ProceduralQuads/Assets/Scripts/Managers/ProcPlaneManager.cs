using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ProcPlaneManager : MonoBehaviour
{
    //public PlayerMovement Movement;
    [SerializeField] private bool _canPlacePoints;
    public bool CanPlacePoints { set => _canPlacePoints = value; }
    [SerializeField] private ProceduralMeshGenerator _proceduralObjectGenerator;
    [SerializeField] private FourPointsController _fourPointsController;
    [SerializeField] private RectangleDrawer _meshPreview;
    private Vector3[] _currentPlane;
    [Header("Sound Events")]
    [SerializeField] private UnityEvent _OnPlacePointEvent;
    [SerializeField] private UnityEvent _OnPreviewEvent;
    [SerializeField] private UnityEvent _OnPlaceMeshEvent;
    void Update()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked; 
        //Rse
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (_canPlacePoints)
            if (Input.GetMouseButtonDown(0))
            {
                if (_fourPointsController.PointCount < 4)
                {
                    _fourPointsController.PlacePoint();
                    //Erase the preview when starting a new mesh
                    if (_fourPointsController.PointCount == 1)
                        _meshPreview.Erase();
                    //When finished placing the four points, draw the preview lines
                    if (_fourPointsController.PointCount == 4)
                    {
                        _currentPlane = _fourPointsController.GetPoints();
                        _meshPreview.Draw(_currentPlane);
                        _OnPreviewEvent.Invoke();

                    }
                    else
                    {
                        _OnPlacePointEvent.Invoke();

                    }
                }  //If there is a plane, generate it
                else if (_currentPlane != null)
                {
                    _proceduralObjectGenerator.Generate(_fourPointsController.GetPoints());
                    _fourPointsController.ResetPoints();
                    _currentPlane = null;
                    _OnPlaceMeshEvent.Invoke();

                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _fourPointsController.ResetPoints();
                _meshPreview.Erase();
            }
    }
}
