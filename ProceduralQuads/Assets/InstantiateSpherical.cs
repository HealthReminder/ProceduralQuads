using UnityEngine;

public class InstantiateSpherical : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects;
    public float radius;
    public float raycastLength = 3000f;

    public void Instantiate()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity);
            instance.SetActive(true);
            instance.transform.parent = transform;
            RaycastHit hit = new RaycastHit();
            bool hasHitSomething = false;
            while (!hasHitSomething)
            {
                Vector3 rPos = transform.position + GetRandomSphericalPosition();
                instance.transform.position = rPos;
                hasHitSomething = Physics.Raycast(instance.transform.position, transform.position - instance.transform.position, out hit, raycastLength);
                Debug.DrawRay(instance.transform.position, transform.position - instance.transform.position, Color.green, 1.0f);
            }

            if (hasHitSomething)
            {
                if (hit.collider)
                {
                    instance.transform.position = hit.point;
                    instance.transform.up = hit.normal;
                }
            }
        }
    }
    private Vector3 GetRandomSphericalPosition()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float inclination = Random.Range(0f, Mathf.PI * 2f);
        float x = radius * Mathf.Sin(inclination) * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(inclination) * Mathf.Sin(angle);
        float z = radius * Mathf.Cos(inclination);
        Vector3 position = new Vector3(x, y, z);
        return position;
    }
}