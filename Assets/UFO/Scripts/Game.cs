using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : SingletonGameobject<Game>
{
    [SerializeField] private Farm _farm;
    [SerializeField] private UI _ui;

    protected override void Awake()
    {
        
        base.Awake();
    }

    private void Start()
    {
        _ = SpawnAnimal();
    }

    private async UniTaskVoid SpawnAnimal()
    {
        while (true)
        {
            _farm.SpawnAnimals(5);
            await UniTask.Delay(5000);
        }
    }

}
