using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _population;

    private void Awake()
    {
        Farm.OnChangePopulation = UpdatePopulation;
    }

    private void UpdatePopulation(int countAnimal)
    {
        _population.text = string.Format("Population: {0}", countAnimal);
    }
}
