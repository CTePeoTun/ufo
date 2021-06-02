using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SimpleTouchController controller;
    [SerializeField] private Transform pointGrab;
    private float moveSpeed = 4f;
    private float grabSpeed = 6f;
    private float grabRotateSpeed = 200f;
    private CancellationTokenSource cts;

    private void Start()
    {
        cts = new CancellationTokenSource();
    }

    private void Update()
    {
        Vector2 positionTouch = controller.GetTouchPosition;
        Vector3 direction = new Vector3(positionTouch.x, 0f, positionTouch.y);
        transform.Translate(direction * Time.deltaTime * moveSpeed);
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
        Grab(animal.transform).Forget();
    }

    private async UniTaskVoid Grab(Transform grabbed)
    {
        while (Vector3.Distance(grabbed.position, pointGrab.transform.position) > 0.01f)
        {
            grabbed.position = Vector3.MoveTowards(grabbed.position, pointGrab.position, Time.deltaTime * grabSpeed);
            grabbed.Rotate(Vector3.one * Time.deltaTime * grabRotateSpeed);
            await UniTask.Yield(cancellationToken: cts.Token);
        }
        grabbed.gameObject.SetActive(false);
        GameController.Collected++; //GAVNOCODE
        if(GameController.Collected == 5)
        {
            GameController.Instance.ShowMeme();
        }
        if (GameController.Collected >= GameController.All)
        {
            GameController.Instance.ShowResult();
        }
    }

    private void OnDestroy()
    {
        cts?.Cancel();
    }
}
