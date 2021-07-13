using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    [SerializeField] private bool _isFree; //SerializeField for observe in inspector 
    private Transform poolParent;

    public bool IsFree => _isFree;

    public void TakeFromPool()
    {
        SetState(false);
    }

    protected abstract void Clear();

    public virtual void InitOnPool()
    {
        poolParent = transform.parent;
        Clear();
        SetState(true);
    }

    public virtual void ReturnToPool()
    {
        transform.parent = poolParent;
        Clear();        
        SetState(true);
    }

    private void SetState(bool isFree)
    {
        this.gameObject.SetActive(!isFree);
        this._isFree = isFree;
    }
}
