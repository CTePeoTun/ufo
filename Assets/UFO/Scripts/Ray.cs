using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;

public class Ray : MonoBehaviour
{
    [SerializeField] private Transform _pointEndGrab;

    private float _grabSpeed = 6f;
    private float _grabRotateSpeed = 200f;
    private CancellationTokenSource _cts;

    private void Start()
    {
        _cts = new CancellationTokenSource();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Animal>(out Animal animal))
        { 
            StartGrab(animal);
        }
    }

    private void StartGrab(Animal animal)
    {
        animal.Stay();
        animal.transform.SetParent(this.transform);
        Grab(animal).Forget();
    }

    private async UniTaskVoid Grab(Animal animal)
    {
        Transform grabbed = animal.transform;
        while (Vector3.Distance(grabbed.position, _pointEndGrab.transform.position) > 0.01f)
        {
            grabbed.position = Vector3.MoveTowards(grabbed.position, _pointEndGrab.position, Time.deltaTime * _grabSpeed);
            grabbed.Rotate(Vector3.one * Time.deltaTime * _grabRotateSpeed);
            await UniTask.Yield(cancellationToken: _cts.Token);
        }
        animal.ReturnToPool();
    }

    private void OnDestroy()
    {
        _cts?.Cancel();
    }
}
