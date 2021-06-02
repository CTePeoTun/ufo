using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class FpsCounter : MonoBehaviour
{
    private Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        label.text = ((int) (1f / Time.unscaledDeltaTime)).ToString(); 
    }
}
