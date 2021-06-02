using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    private Vector3 targetPoint;
    private CancellationTokenSource cts;
    private NavMeshAgent agent;
    private Collider _collider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<Collider>();
        cts = new CancellationTokenSource();
    }

    private void Start()
    {
        MakeChoice().Forget();
        MoveToNewPoint();
    }


    private async UniTaskVoid MakeChoice()
    {
        while (true)
        {
            var delay = Random.Range(3000, 10000);
            await UniTask.Delay(delay, cancellationToken: cts.Token);
            MoveToNewPoint();
        }
    }

    private void MoveToNewPoint()
    {
        targetPoint = GetTargetPoint();
        agent.SetDestination(targetPoint);
    }

    private Vector3 GetTargetPoint()
    {
        var x = Random.Range(-20f, 20f);
        var z = Random.Range(-20f, 20f);
        return new Vector3(x, 0f, z);
    }

    private void OnDestroy()
    {
        cts?.Cancel();
    }

    public void Stay()
    {
        cts?.Cancel();
        agent.isStopped = true;
        _collider.enabled = false;
        agent.enabled = false;
    }
}
