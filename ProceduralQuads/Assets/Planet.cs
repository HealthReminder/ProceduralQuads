using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float gravitationalForce;
    [SerializeField] private float radius;
    [SerializeField] private float surfaceOffset = 0.1f;

    private List<Rigidbody> rigidbodiesInfluence = new List<Rigidbody>();

    private void FixedUpdate()
    {
        foreach (Rigidbody rigidbody in rigidbodiesInfluence)
        {
            if (!IsGrounded(rigidbody) && rigidbody.useGravity)
            {
                float distance = Vector3.Distance(transform.position, rigidbody.position);
                if (distance <= radius)
                {
                    Vector3 direction = (transform.position - rigidbody.position).normalized;
                    float gravityStrength = gravitationalForce * rigidbody.mass / (distance * distance);
                    rigidbody.AddForce(direction * gravityStrength, ForceMode.Force);

                    Vector3 upDirection = (rigidbody.position - transform.position).normalized;
                    Quaternion targetRotation = Quaternion.FromToRotation(rigidbody.transform.up, upDirection) * rigidbody.transform.rotation;
                    rigidbody.MoveRotation(targetRotation);
                }
            }
        }
    }

    public void AddRigidbody(Rigidbody rb)
    {
        if (rb != null)
        {
            rigidbodiesInfluence.Add(rb);
        }
    }

    public void RemoveRigidbody(Rigidbody rb)
    {
        if (rb != null)
        {
            rigidbodiesInfluence.Remove(rb);
        }
    }

    private bool IsGrounded(Rigidbody rb)
    {
        return Physics.Raycast(rb.position, rb.position-transform.position, out RaycastHit hit, surfaceOffset + 0.01f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}