using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public bool CanAim { set => _canAim = value; }
    [SerializeField] private bool _canAim = true;
    [SerializeField] private Transform _playerTransform; // Reference to the player's transform
    [SerializeField] private Camera _playerCamera; // Reference to the player's camera
    [SerializeField] private GameObject _ball; // Reference to the ball GameObject
    [SerializeField] private GameObject _line; // Reference to the line GameObject

    private bool isActive = false; // Flag to track whether the ball should be active

    void Start()
    {
        // Deactivate the ball and line initially
        _ball.SetActive(false);
        _line.SetActive(false);
    }

    void Update()
    {
        if (_canAim)
        {
            // Check if the player is looking at something
            RaycastHit hit;
            bool isLookingAtSomething = Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out hit);

            // Activate/deactivate the ball based on whether the player is looking at something
            if (isLookingAtSomething && hit.collider.gameObject != _ball)
            {
                _ball.SetActive(true);
                _line.SetActive(true);

                // Set the position of the ball to where the player is looking
                _ball.transform.position = hit.point;

                // Set the position of the line to point from the set transform to the ball
                _line.GetComponent<LineRenderer>().SetPosition(0, transform.position);
                _line.GetComponent<LineRenderer>().SetPosition(1, hit.point);
            }
            else
            {
                _ball.SetActive(false);
                _line.SetActive(false);
            }
        } else
        {
            _ball.SetActive(false);
            _line.SetActive(false);
        }
    }
}