using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : SingletonGameobject<GameController>
{
    public static int Collected { get; set; } = 0;
    public static int All { get; set; } = 0;

    [SerializeField] private Button reload;
    [SerializeField] private Animation meme;
    [SerializeField] private GameObject animalStack;


    protected override void Awake()
    {
        Collected = 0;
        reload.gameObject.SetActive(false);
        All = animalStack.GetComponentsInChildren<Animal>().Length;
    }

    public void ShowResult()
    {
        reload.gameObject.SetActive(true);
    }

    public void ShowMeme()
    {
        meme.Play();
    }

    public void Reload()
    {
        SceneManager.LoadScene("Grossland");
    }
    
}
