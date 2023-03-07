using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public Camera playerCamera; // Reference to the player's camera
    public GameObject ball; // Reference to the ball GameObject
    public GameObject line; // Reference to the line GameObject

    private bool isActive = false; // Flag to track whether the ball should be active

    void Start()
    {
        // Deactivate the ball and line initially
        ball.SetActive(false);
        line.SetActive(false);
    }

    void Update()
    {
        // Check if the player is looking at something
        RaycastHit hit;
        bool isLookingAtSomething = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit);

        // Activate/deactivate the ball based on whether the player is looking at something
        if (isLookingAtSomething && hit.collider.gameObject != ball)
        {
            ball.SetActive(true);
            line.SetActive(true);

            // Set the position of the ball to where the player is looking
            ball.transform.position = hit.point;

            // Set the position of the line to point from the set transform to the ball
            line.GetComponent<LineRenderer>().SetPosition(0, transform.position);
            line.GetComponent<LineRenderer>().SetPosition(1, hit.point);
        }
        else 
        {
            ball.SetActive(false);
            line.SetActive(false);
        }
    }
}