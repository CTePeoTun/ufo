using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : PoolObject
{
    [SerializeField] private List<T> poolObjects;
    [SerializeField] private List<T> poolObjectPrefabs;
    [SerializeField] private int startSize = 10;

    public int Size => poolObjects.Count;

    protected virtual void Awake()
    {
        for (int i = 0; i < startSize; i++)
        {
            CreatePoolObject();
        }
    }

    protected virtual T CreatePoolObject()
    {
        var poolObject = Instantiate(poolObjectPrefabs.PickRandom(), this.transform);
        poolObject.InitOnPool();
        poolObjects.Add(poolObject);
        return poolObject;
    }

    public virtual T GetFromPool()
    {
        var poolObject = poolObjects.Find(po => po.IsFree == true);
        if (poolObject == null)
        {
            poolObject = CreatePoolObject();
        }
        poolObject.TakeFromPool();
        return poolObject;
    }

    protected virtual void ReturnAllToPool()
    {
        poolObjects.ForEach(po => po.ReturnToPool());
    }
}
