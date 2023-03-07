using UnityEngine;

public class AI : MonoBehaviour
{
    // Define the states of the Finite State Machine
    private enum State
    {
        Idle,
        Patrol,
        Chase,
        Attack
    }

    // Define the variables needed for the AI
    private State currentState;
    private Transform playerTransform;
    private float moveSpeed = 5f;

    private void Start()
    {
        // Set the initial state of the AI to Idle
        currentState = State.Idle;

        // Find the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Update the state of the AI
        UpdateState();

        // Perform actions based on the current state of the AI
        switch (currentState)
        {
            case State.Idle:
                // Perform idle behavior
                break;

            case State.Patrol:
                // Perform patrol behavior
                break;

            case State.Chase:
                // Perform chase behavior
                ChasePlayer();
                break;

            case State.Attack:
                // Perform attack behavior
                break;
        }
    }

    private void UpdateState()
    {
        // Determine which state the AI should be in
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < 5f)
        {
            currentState = State.Attack;
        }
        else if (distanceToPlayer < 10f)
        {
            currentState = State.Chase;
        }
        else
        {
            currentState = State.Patrol;
        }
    }

    private void ChasePlayer()
    {
        // Move towards the player
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
    }
}