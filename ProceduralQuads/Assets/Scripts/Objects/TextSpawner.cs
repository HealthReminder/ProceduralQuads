using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSpawner : MonoBehaviour
{
    public float Delay;
    public float YOffset;
    public Gradient Gradient;
    public GameObject TextPrefab;
    public Transform CanvasWorldSpace;
    public List<GameObject> generatedObjects;
    void Start()
    {
        generatedObjects = new List<GameObject>();
    }
    public void GenerateNewText (Vector3 spawnPos)
    {
        GameObject newObject = Instantiate(TextPrefab, spawnPos + new Vector3(0, YOffset,0), Quaternion.identity, CanvasWorldSpace);
        newObject.SetActive(true);
        generatedObjects.Add(newObject);
        StartCoroutine(DestroyObjectRoutine(newObject,Delay));
    }
    IEnumerator DestroyObjectRoutine(GameObject obj, float delay)
    {
        float progress = 0;
        progress += Time.deltaTime;
        while (progress < delay)
        {
            progress += Time.deltaTime;
            float n = Mathf.InverseLerp(0, delay, progress);
            obj.GetComponent<TextMeshProUGUI>().color = Gradient.Evaluate(n);
            yield return null;
        }
        generatedObjects.Remove(obj);
        Destroy(obj);
        yield break;
    }

}
