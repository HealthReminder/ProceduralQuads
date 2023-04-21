using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The pooling class is able to create pools of any kind of gameObjects/components
/// Objects are returned using the ReturnToPool component
/// </summary>
/// <typeparam name="PoolObject">The is the type of generic object to pool</typeparam>
public class Pooling<PoolObject> where PoolObject : Component
{
    ///The difference between a queue and a list is that a queue has no indexes
    ///The first items that got in the queue will be the first to leave
    private Queue<PoolObject> _poolQueue = new Queue<PoolObject>();
    ///Stores the received prefab to instantiate the pool
    private PoolObject _prefab;
    ///The parent of instantiated objects
    private Transform _parent;
    ///The layer of instantiated objects
    private LayerMask _layer;

    public Pooling(PoolObject prefab, int initialPoolSize, Transform parent, int layerIndex)
    {
        _prefab = prefab;
        _parent = parent;
        _layer = layerIndex;

        for (int i = 0; i < initialPoolSize; i++)
        {
            PoolObject obj;
            obj = GameObject.Instantiate(_prefab, parent);
            obj.gameObject.layer = _layer;
            obj.gameObject.SetActive(false);
            obj.transform.parent = _parent;
            ///Add to the queue
            _poolQueue.Enqueue(obj);
        }
    }
    /// <summary>
    /// Get the next object from the pool 
    /// </summary>
    /// <param name="position">The new position of the next object</param>
    /// <param name="rotation">The new rotation of the next object</param>
    /// <returns>Returns the next object</returns>
    public PoolObject GetFromPool(Vector3 position, Quaternion rotation)
    {
        PoolObject obj;

        if (_poolQueue.Count > 0)
        {
            obj = _poolQueue.Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
        }
        else
        {
            obj = GameObject.Instantiate(_prefab, position, rotation, _parent);
            obj.gameObject.layer = _layer;

        }
        if (obj.GetComponent<Rigidbody>())
            obj.GetComponent<Rigidbody>().velocity = Vector3.zero;

        return obj;
    }
    /// <summary>
    /// Return an object to the pool
    /// Deactivate it
    /// </summary>
    /// <param name="obj">Object to be deactivated</param>
    public void ReturnToPool(PoolObject obj)
    {
        obj.gameObject.SetActive(false);
        _poolQueue.Enqueue(obj);
    }
}