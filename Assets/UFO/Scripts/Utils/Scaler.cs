using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;

    private float maxTimeCurve;    

    private void Awake()
    {
        maxTimeCurve = animationCurve.keys[animationCurve.keys.Length - 1].time;
    }

    private void Update()
    {
        transform.localScale = Vector3.one * animationCurve.Evaluate(Time.time);
    }


}
