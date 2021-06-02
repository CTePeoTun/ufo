using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilledBar : MonoBehaviour
{
    [SerializeField] private Image fill;

    private void Awake()
    {
        fill.type = Image.Type.Filled;
    }

    public void UpdateProgress(float current, float max)
    {
        if (fill != null)
        {
            fill.fillAmount = current > 0 ? current / max : 0;
        }        
    }
}
