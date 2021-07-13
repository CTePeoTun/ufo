using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Pool<Animal>
{
    public static Action<int> OnChangePopulation;

    private List<Animal> _animals = new List<Animal>();

    public void SpawnAnimals(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var animal = GetFromPool();
            _animals.Add(animal);
            animal.Move();
            animal.OnGrab = RemoveAnimal;            
        }
        OnChangePopulation?.Invoke(_animals.Count);
    }

    private void RemoveAnimal(Animal animal)
    {
        _animals.Remove(animal);
        OnChangePopulation?.Invoke(_animals.Count);
    }
}
